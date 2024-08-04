using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels.Pacientes
{
    public class PacienteContacto
    {
        [Key, ForeignKey("Paciente")]

        public Guid IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public string Ocupacion { get; set; } 
        public string Correo { get; set; } 
        public int Telefono { get; set; }
        public decimal GastoSemanal { get;  set; }

    }
}
