using lojagames.Data;
using lojagames.Model;
using Microsoft.EntityFrameworkCore;

namespace lojagames.Service.Implements
{
    public class ProdutoService : IProdutoServise
    {
        private readonly AppDbContext _Context;

        public ProdutoService(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Produto>> GettAll()
        {
            return await _Context.Produtos.ToListAsync();
              
        }
        public async Task<Produto?> Create(Produto produto)
        {

            throw new NotImplementedException();

            /*if (produto.Categoria is not null)
            {
                var BuscarTema = await _Context.Temas.FindAsync(produto.Descricao.Id);

                if (BuscarTema is null)
                    return null;
                
            } */
            /*
            produto.Categoria = produto.Categoria is not null ? _Context.Categoria.FirstOrDefault
            (t => t.Id == produto.Descricao.Id) : null;
            await _Context.Produtos.AddAsync(produto);
            await _Context.SaveChangesAsync();

            return produto; */
        }

        public async Task Delete(Produto produto)
        {
            _Context.Produtos.Remove(produto); 
            await _Context.SaveChangesAsync();  
        }

        public Task<Produto?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetByNome(string titulo)
        {
            throw new NotImplementedException();
        }

        public Task<Produto?> GetByPreco(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto?> Update(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
