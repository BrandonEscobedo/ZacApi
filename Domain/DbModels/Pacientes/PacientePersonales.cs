using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DbModels.Pacientes
{
    public class PacientePersonales
    {
        [Key,ForeignKey("Paciente")]
        public Guid IdPaciente { get; set; }
        [JsonIgnore]
        public Paciente? Paciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Genero Genero { get; set; }
        public short Edad { get; set; }
        public string Nombres { get;  set; }
        public string Apellido { get;  set; }


    }
}
