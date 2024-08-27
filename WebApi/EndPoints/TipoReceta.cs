using Application.Recetas.TipoRecetas;
using MediatR;

namespace WebApi.EndPoints
{
    public  static class TipoReceta
    {
        public static void TipoRecetaEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/V1/TipoReceta", async (TipoRecetaCommand tipoRecetaCommand, ISender sender) =>
            {
                await sender.Send(tipoRecetaCommand);
                return Results.Ok();
            });
        }
    }
}
