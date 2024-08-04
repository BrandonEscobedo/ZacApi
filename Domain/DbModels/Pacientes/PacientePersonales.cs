using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DbModels.Pacientes
{
    public class PacientePersonales
    {
        [Key,ForeignKey("Paciente")]
        public Guid IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Genero Genero { get; set; }
        public short Edad { get; set; }
        public string PrimerNombre { get;  set; }
        public string? SegundoNombre { get;  set; }
        public string PrimerApellido { get;  set; }
        public string SegundoApellido { get;  set; }

    }
}
