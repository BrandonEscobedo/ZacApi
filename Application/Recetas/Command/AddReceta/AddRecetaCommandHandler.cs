using AutoMapper;
using Domain.Abstractions;
using Domain.DbModels;
using Domain.Enums;
using MediatR;

namespace Application.Recetas.Command.AddReceta
{
    internal sealed class AddRecetaCommandHandler(IRecetaRepository _recetaRepository ) : IRequestHandler<AddRecetaCommand>
    {
        public async Task Handle(AddRecetaCommand request, CancellationToken cancellationToken)
        {
            var receta = new Receta(
                request.RecetaRequest.IdTipoReceta,
                request.RecetaRequest.ModoPreparacion,
                request.RecetaRequest.ModoPreparacion
                );
            foreach (var ingredienteRequest in request.RecetaRequest.Ingredientes)
            {
                if (!Enum.TryParse<TipoIngrediente>(ingredienteRequest.TipoIngrediente, true, out var tipoIngrediente))
                {
                    //Agregar Fluent Validation
                }

                var ingrediente = new Ingrediente(
                  tipoIngrediente,
                    ingredienteRequest.IdAlimento,
                    ingredienteRequest.UnidadesTotales,
                    Guid.Empty
                    );
                receta.AddIngrediente(ingrediente);
            }
            await _recetaRepository.AddReceta(receta);
        }
    }
}
