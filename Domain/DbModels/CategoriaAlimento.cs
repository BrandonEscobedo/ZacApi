using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class CategoriaAlimento
    {
        public int IdCategoriaAlimento { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        //No utilizar Cadenas Primitivas si no es necesario, usar obejetoscomplejos osea value object
        public ICollection<Alimento>? AlimentosNav { get; set; }
    }
}
