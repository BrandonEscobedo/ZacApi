using Application.Alimentos.AddAlimento;
using MediatR;

namespace WebApi.EndPoints
{
    public static class Alimentos
    {
        public static void AlimentosEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/V1/Alimentos/AddAlimento", async (AddAlimentoCommand  addAlimentoCommand,ISender sender) =>
            {
                await sender.Send(addAlimentoCommand);
                return Results.Ok();
            });
        }
    }
}
