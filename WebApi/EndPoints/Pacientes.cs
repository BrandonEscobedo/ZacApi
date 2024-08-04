using Application.DTO.Request.Pacientes;
using Application.Pacientes.AddPaciente;
using MediatR;

namespace WebApi.EndPoints
{
    public static class Pacientes
    {
        public static void PacienteEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/Paciente");
            group.MapPost("", async (PacienteRequest pacienteResquest, ISender send) =>
            {
                await send.Send(new AddPacienteCommand(pacienteResquest));
                return Results.Ok();
            });
        }
    }
}
