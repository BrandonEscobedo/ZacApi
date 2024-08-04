using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class Padecimiento
    {
        [Key]
        public int IdPadecimiento { get;private set; }
        public string Nombre { get;private set; } = string.Empty;
        public string Descripcion { get ;private  set; }=string.Empty;
        [JsonIgnore]
        public ICollection<PacientePadecimiento>? PacientePadecimientos { get; set; }
        private Padecimiento()
        {
            
        }
        internal static Padecimiento Create(string nombre,string descripcion)
        {
            return new Padecimiento
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
        }

    }
}
