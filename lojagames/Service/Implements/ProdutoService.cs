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
            return await _Context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();
        }
        public async Task<Produto?> Create(Produto produto)
        {
            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _Context.Categorias
                    .FindAsync(produto.Categoria.Id);

                if (BuscaCategoria is null)
                    return null;

                produto.Categoria = BuscaCategoria;

            }
            await _Context.Produtos.AddAsync(produto);
            await _Context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(Produto produto)
        {
            _Context.Produtos.Remove(produto); 
            await _Context.SaveChangesAsync();  
        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _Context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(i => i.Id == id);

                return Produto;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produto = await _Context.Produtos
                    .Include(p => p.Categoria)
                    .Where(p => p.Nome.Contains(nome))
                    .ToListAsync();

            return Produto;
        }

        public async Task<IEnumerable<Produto?>> GetByPreco(decimal precoInicial, decimal precoFinal)
        {
            var produto = await _Context.Produtos
               .Include(p => p.Categoria)
               .Where(p => p.Preco >= precoInicial && p.Preco <= precoFinal)
               .ToListAsync();

            return produto;
        }

        public async Task<Produto?> Update(Produto produto)
        {
            var ProdutoUpdate = await _Context.Produtos.FindAsync(produto.Id);

            if (ProdutoUpdate is not null)
                return null;

            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _Context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscaCategoria is null)
                    return null;

                produto.Categoria = BuscaCategoria;

            }

            _Context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _Context.Entry(produto).State = EntityState.Modified;
            await _Context.SaveChangesAsync();

            return produto;

        }
    }
}
