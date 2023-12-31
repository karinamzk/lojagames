﻿using FluentValidation;
using lojagames.Model;
using lojagames.Service;
using Microsoft.AspNetCore.Mvc;


namespace lojagames.Controller
{
    [Route("~/produtos")] 
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServise _produtoService;
        private readonly IValidator<Produto> _produtoValidator;

        public ProdutoController(
          IProdutoServise produtoService,
          IValidator<Produto> produtoValidator)
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GettAll()
        {
            return Ok(await _produtoService.GettAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _produtoService.GetById(id);

            if (Resposta is null)
            {
                return NotFound();
            }

            return Ok(Resposta);
        }


        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GettByNome(string nome)
        {
            return Ok(await _produtoService.GetByNome(nome));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
            {
                return BadRequest("Produto não encontrado!");
            }
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.Id == 0)
                return BadRequest("Id do Produto é inválido!");

            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Update(produto);

            if (Resposta is null)
                return NotFound("Produto não foi encontrada");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(long id)
        {
            var BuscaProduto = await _produtoService.GetById(id);

            if (BuscaProduto is null)
                return NotFound("Produto não foi encontrada");

            await _produtoService.Delete(BuscaProduto);

            return NoContent();
        }
    }
}
