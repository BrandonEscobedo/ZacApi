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
    internal sealed class TipoRecetaRepository(ZacContext _context) : ITipoRecetaRepository
    {
        public async Task AddTipoReceta(TipoReceta tipoReceta)
        {

            _context.Add(tipoReceta);
            await _context.SaveChangesAsync();
        }
    }
}
