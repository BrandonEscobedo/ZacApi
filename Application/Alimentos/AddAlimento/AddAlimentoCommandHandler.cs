using Domain.Abstractions;
using Domain.DbModels;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alimentos.AddAlimento
{
    internal sealed class AddAlimentoCommandHandler(IAlimentoRepository _alimentoRepository) : IRequestHandler<AddAlimentoCommand>
    {
        public async Task Handle(AddAlimentoCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<Unidad>(request.Unidad, true, out var unidad))
            {
                //Agregar Fluent Validation

            }
            var alimento = new Alimento(
                request.Cantidad,
                request.IdCategoria,
               unidad,
                request.Nombre
                );
            await _alimentoRepository.AddAlimentoAsync(alimento);
        }
    }
}
