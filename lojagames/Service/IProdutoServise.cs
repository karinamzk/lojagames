using lojagames.Model;

namespace lojagames.Service
{
    public interface IProdutoServise
    {
        Task<IEnumerable<Produto>> GettAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);

        Task<Produto?> GetByPreco(decimal precoInicial, decimal precoFinal);

    }
}
