using Domain.DbModels.Pacientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class PacientePadecimiento
    {
        public Guid IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }
        public int IdPadecimiento { get; set; }
        public virtual Padecimiento? Padecimiento { get; set; } 
    }
}
