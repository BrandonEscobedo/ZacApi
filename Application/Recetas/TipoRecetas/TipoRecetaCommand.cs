using MediatR;

namespace Application.Recetas.TipoRecetas
{
    public record TipoRecetaCommand(string NombreReceta, string Descripcion):IRequest;
}
