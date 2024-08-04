using Application.DTO.Request.Pacientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pacientes.AddPaciente
{
    public record AddPacienteCommand(PacienteRequest Paciente):IRequest;
}
