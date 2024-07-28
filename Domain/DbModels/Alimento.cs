using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class Alimento
    {
        public int IdAlimento { get; set; }
        public int Cantidad { get; set; }
        public int IdCategoria { get; set; }
        public Unidad Unidad { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public CategoriaAlimento? categoriaAlimentoNav { get; set; }
    }
}
