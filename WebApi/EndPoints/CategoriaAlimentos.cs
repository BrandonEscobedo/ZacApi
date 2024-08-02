using Application.CategoriaAlimentos;
using MediatR;

namespace WebApi.EndPoints
{
    public static class CategoriaAlimentos
    {
        public static void CategoriaAlimentosEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/V1/Categorias/AddCategoria", async (CategoriaAlimentoCommand categoriaAlimentoCommand ,ISender sender) =>
            {
                await  sender.Send(categoriaAlimentoCommand);
                return Results.Ok();

            });
        }
    }
}
