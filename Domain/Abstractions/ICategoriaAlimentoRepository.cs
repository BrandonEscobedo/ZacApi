using Domain.DbModels;

namespace Domain.Abstractions
{
    public interface ICategoriaAlimentoRepository
    {
        public Task AddCategoriaAlimentoAsync(CategoriaAlimento categoriaAlimento);
        public Task<CategoriaAlimento> GetCategoriaAlimentoAsync(int idCategoria);
        public Task<List<CategoriaAlimento>> GetAllCategoriaAlimento();
        public Task RemoveCategoriaAlimento(int idCategoria);
    }
}
