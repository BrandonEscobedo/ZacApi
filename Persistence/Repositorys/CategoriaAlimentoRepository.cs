using Domain.Abstractions;
using Domain.DbModels;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDb;

namespace Infrastructure.Repositorys
{
    internal sealed class CategoriaAlimentoRepository(ZacContext dbContext) : ICategoriaAlimentoRepository
    {
        public async Task AddCategoriaAlimentoAsync(CategoriaAlimento categoriaAlimento)
        {
            dbContext.CategoriaAlimentos.Add(categoriaAlimento);
            await dbContext.SaveChangesAsync();
        }
        public async Task<List<CategoriaAlimento>> GetAllCategoriaAlimento()
        {
            return   await dbContext.CategoriaAlimentos.ToListAsync();
        }

        public Task<CategoriaAlimento> GetCategoriaAlimentoAsync(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCategoriaAlimento(int idCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
