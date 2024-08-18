using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class Ingrediente
    {
        public int IdIngrediente { get; private set; }
        public int IdAlimento { get; private set; }
        public TipoIngrediente TipoIngrediente { get; private set; }
        public int UnidadesTotales { get; private set; }
        public Alimento? AlimentoNav { get;  set; }

        public Ingrediente(TipoIngrediente tipoIngrediente,
            int idAlimento,
            int unidadesTotales)
        {
            TipoIngrediente = tipoIngrediente;
            IdAlimento = idAlimento;
            UnidadesTotales = unidadesTotales;
        }
        public Ingrediente()
        {

        }
    }
}
