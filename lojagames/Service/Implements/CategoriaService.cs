using lojagames.Data;
using lojagames.Model;
using Microsoft.EntityFrameworkCore;

namespace lojagames.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _Context;
        public CategoriaService(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Categoria>> GettAll()
        {
            throw new NotImplementedException();
        }
        public Task<Categoria?> Create(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> GetByTipo(string tipo)
        {
            throw new NotImplementedException();
        }

      

        public Task<Categoria?> Update(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
