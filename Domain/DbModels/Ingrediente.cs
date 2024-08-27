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
        public Guid IdIngrediente { get; private set; }
        public int IdAlimento { get; private set; }
        public Guid IdReceta { get; set; }
        public Receta? RecetaNav { get; set; }
        public TipoIngrediente TipoIngrediente { get; private set; }
        public int UnidadesTotales { get; private set; }
        public Alimento? AlimentoNav { get;  set; }

        public Ingrediente(TipoIngrediente tipoIngrediente,
            int idAlimento,
            int unidadesTotales,
            Guid idReceta)
        {
            TipoIngrediente = tipoIngrediente;
            IdAlimento = idAlimento;
            UnidadesTotales = unidadesTotales;
            IdReceta = idReceta;
            IdIngrediente = Guid.NewGuid();
        }
        public Ingrediente()
        {

        }
    }
}
