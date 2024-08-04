using Domain.Abstractions;
using Domain.DbModels.Pacientes;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Paciente> GetPacienteById(Guid IdPaciente)
        {
            var paciente =await _context.Paciente
                .Where(x => x.IdPaciente == IdPaciente)
                .Include(x => x.PacientePadecimientos).ThenInclude(x=>x.Padecimiento)
                .Include(x => x.Contacto)
                .Include(x => x.Personales)
                .Include(x => x.SintomasAntecedentes)
                .FirstOrDefaultAsync();
            if (paciente != null)
            {
                return paciente;
            }
            return null!;
        }
    }
}
