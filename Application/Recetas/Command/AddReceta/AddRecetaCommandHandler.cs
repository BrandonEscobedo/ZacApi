using AutoMapper;
using Domain.Abstractions;
using Domain.DbModels;
using Domain.Enums;
using MediatR;

namespace Application.Recetas.Command.AddReceta
{
    internal sealed class AddRecetaCommandHandler(IRecetaRepository _recetaRepository,IMapper mapper) : IRequestHandler<AddRecetaCommand>
    {
        public async Task Handle(AddRecetaCommand request, CancellationToken cancellationToken)
        {
            var receta = mapper.Map<Receta>(request);
           
            if (receta.Ingredientes != null)
            {
        
                foreach (var ingredienteRequest in request.RecetaRequest.Ingredientes)
                {
                    if (!Enum.TryParse<Genero>(ingredienteRequest.TipoIngrediente, true, out var tipoIngrediente))
                    {
                        //Agregar Fluent Validation
                    }
                    else
                    {
                        
                    }          
                }      
            }
            await _recetaRepository.AddReceta(receta);
        }
    }
}
