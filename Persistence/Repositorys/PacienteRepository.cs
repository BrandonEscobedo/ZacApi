using Domain.Abstractions;
using Domain.DbModels.Pacientes;
using Persistence.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositorys
{
    internal sealed class PacienteRepository(ZacContext _context) : IPacienteRepository
    {
        public async Task AddPacienteAsync(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
