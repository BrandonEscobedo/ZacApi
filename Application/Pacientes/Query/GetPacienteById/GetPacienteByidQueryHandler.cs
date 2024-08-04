using Domain.Abstractions;
using Domain.DbModels.Pacientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pacientes.Query.GetPacienteById
{
    internal sealed class GetPacienteByidQueryHandler(IPacienteRepository _pacienteRepository) : IRequestHandler<GetPacienteByidQuery, Paciente>
    {
        public async Task<Paciente> Handle(GetPacienteByidQuery request, CancellationToken cancellationToken)
        {
            var response = await _pacienteRepository.GetPacienteById(request.IdPaciente);
            if(response!=null)
            {
                return response;
            }
            return null!;
        }
    }
}
