using Domain.DbModels;

namespace Domain.Abstractions
{
    public interface ITipoRecetaRepository
    {
        Task AddTipoReceta(TipoReceta tipoReceta);
    }
}
