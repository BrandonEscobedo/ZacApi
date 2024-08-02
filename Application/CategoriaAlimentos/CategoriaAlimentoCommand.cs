using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoriaAlimentos
{
    public record CategoriaAlimentoCommand(string CategoriaAlimento, string Descripcion):IRequest;
}
