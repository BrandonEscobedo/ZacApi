using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class Padecimiento
    {

        public int IdPadecimiento { get; set; }
        public string Nombre { get;  set; }
        public string Descripcion { get ;  set; }
        public ICollection<PacientePadecimiento>? PacientePadecimientos { get; set; }

    }
}
