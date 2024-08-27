using Application.DTO.Request.Recetas;
using Application.Recetas.Command.AddReceta;
using MediatR;

namespace WebApi.EndPoints
{
    public static class Recetas
    {
        public static void RecetasEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/V1/Recetas",async (RecetaRequest receta, ISender sender) =>
            {
                await sender.Send(new AddRecetaCommand(receta));
                return Results.Ok();
            });
        }
    }
}
