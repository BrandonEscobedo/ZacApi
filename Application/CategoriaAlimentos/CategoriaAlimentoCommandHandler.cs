using Domain.Abstractions;
using Domain.DbModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoriaAlimentos
{
    internal sealed class CategoriaAlimentoCommandHandler(ICategoriaAlimentoRepository _categoriaAlimentoRepository) :
        IRequestHandler<CategoriaAlimentoCommand>
    {
        public async Task Handle(CategoriaAlimentoCommand request, CancellationToken cancellationToken)
        {
            var CategoriaAlimento = new CategoriaAlimento
                  (request.CategoriaAlimento,
                  request.Descripcion);
            await _categoriaAlimentoRepository.AddCategoriaAlimentoAsync(CategoriaAlimento);
        }
    }
}
