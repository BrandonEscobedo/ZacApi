using Application.DTO.Request.Pacientes;
using Application.Pacientes.Command.AddPaciente;
using Application.Pacientes.Query.GetPacienteById;
using Domain.DbModels.Pacientes;
using MediatR;

namespace WebApi.EndPoints
{
    public static class Pacientes
    {
        public static void PacienteEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/V1/Paciente");
            group.MapPost("", async (PacienteRequest pacienteResquest, ISender send) =>
            {
                await send.Send(new AddPacienteCommand(pacienteResquest));
                return Results.Ok();
            });
            group.MapGet("/{IdPaciente}", async (Guid IdPaciente, ISender send) =>
            {
                var response = await send.Send(new GetPacienteByidQuery(IdPaciente));
                if (response != null)
                {
                    return Results.Ok(response);
                }
                return Results.BadRequest(IdPaciente);
            });
        }
    }
}
