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
    internal sealed class AlimentoRepository(ZacContext DbContext) : IAlimentoRepository
    {
        public async Task AddAlimentoAsync(Alimento alimento)
        {
             DbContext.Alimentos.Add(alimento);
            await DbContext.SaveChangesAsync();
        }
    }
}
