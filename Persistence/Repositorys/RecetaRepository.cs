using Domain.Abstractions;
using Domain.DbModels;
using Persistence.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositorys
{
    internal sealed class RecetaRepository(ZacContext _context) : IRecetaRepository
    {
        public async Task AddReceta(Receta recetas)
        {
            _context.Recetas.Add(recetas);
            await _context.SaveChangesAsync();
        }
    }
}
