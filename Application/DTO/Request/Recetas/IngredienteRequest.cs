using Domain.DbModels;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Recetas
{
    public class IngredienteRequest
    {
        public int IdAlimento { get;  set; }
        public string TipoIngrediente { get; set; } = string.Empty;
        public int UnidadesTotales { get;  set; }
    }
}
