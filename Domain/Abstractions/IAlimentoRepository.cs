using Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IAlimentoRepository
    {
        public Task AddAlimentoAsync(Alimento alimento);

    }
}
