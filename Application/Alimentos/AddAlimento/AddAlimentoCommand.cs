using Domain.DbModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alimentos.AddAlimento
{
    public record AddAlimentoCommand(int Cantidad,int IdCategoria,string Unidad, string Nombre):IRequest;
}
