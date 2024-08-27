using AutoMapper;
using Domain.Abstractions;
using Domain.DbModels;
using Domain.DbModels.Pacientes;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Pacientes.Command.AddPaciente
{
    internal class AddPacienteCommandHandler(IPacienteRepository _pacienteRepository, IMapper _mapper) : IRequestHandler<AddPacienteCommand>
    {
        public async Task Handle(AddPacienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pacienteContacto = _mapper.Map<PacienteContacto>(request.Paciente.PacienteContactoRequest);
                var pacientePersonales = _mapper.Map<PacientePersonales>(request.Paciente.PersonalesRequest);
                var pacienteSintomas = _mapper.Map<PacienteSintomasAntecedentes>(request.Paciente.SintomasRequest);
                if (!Enum.TryParse<Genero>(request.Paciente.PersonalesRequest.Genero, true, out var genero))
                {
                    //Agregar Fluent Validation
                }
                else
                {
                    pacientePersonales.Genero = genero;
                }
                var paciente = new Paciente(
                    pacientePersonales, 
                    pacienteContacto,
                    pacienteSintomas);
                if (request.Paciente.PadecimientosRequest != null)
                {
                    foreach (var padecimiento in from padecimientoDto in request.Paciente.PadecimientosRequest
                                                 let padecimiento = _mapper.Map<Padecimiento>(padecimientoDto)
                                                 select padecimiento)
                    {
                        paciente.AddPadecimiento(padecimiento.IdPadecimiento);
                    }
                }
                await _pacienteRepository.AddPacienteAsync(paciente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

