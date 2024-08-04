using Domain.DbModels.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IPacienteRepository
    {
        public Task AddPacienteAsync(Paciente paciente);
        public  Task<Paciente> GetPacienteById(Guid IdPaciente);

    }
}
