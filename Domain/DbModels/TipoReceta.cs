using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class TipoReceta
    {
        
        public int IdTipoReceta { get; set; }
        public string NombreReceta { get;private set; }
        public string Descripcion { get;private set; }
        public List<Recetas>? Recetas { get; set; }
        public TipoReceta(string nombreReceta, string descripcion)
        {
            NombreReceta = nombreReceta;
            Descripcion = descripcion;

        }
    }
}
