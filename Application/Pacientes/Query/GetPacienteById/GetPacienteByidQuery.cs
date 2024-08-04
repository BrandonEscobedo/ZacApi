using Domain.DbModels.Pacientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pacientes.Query.GetPacienteById
{
    public record GetPacienteByidQuery(Guid IdPaciente):IRequest<Paciente>;
}
