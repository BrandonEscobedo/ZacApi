using Application.DTO.Request.Recetas;
using Domain.DbModels;
using MediatR;

namespace Application.Recetas.Command.AddReceta
{
    public record AddRecetaCommand(RecetaRequest RecetaRequest) : IRequest;

}
