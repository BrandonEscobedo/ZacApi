using Domain.Abstractions;
using Domain.DbModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recetas.TipoRecetas
{
    internal sealed class TipoRecetaCommandHandler(ITipoRecetaRepository _tipoRecetaRepository) : IRequestHandler<TipoRecetaCommand>
    {
        public async Task Handle(TipoRecetaCommand request, CancellationToken cancellationToken)
        {

            TipoReceta tipoReceta = new TipoReceta(
                request.NombreReceta,
                request.Descripcion);
            await _tipoRecetaRepository.AddTipoReceta(tipoReceta);
        }
    }
}
