using Domain.DbModels.Pacientes;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Pacientes
{
    public class PacientePersonalesRequest
    {
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public short Edad { get; set; }
        public string PrimerNombre { get; set; } 
        public string? SegundoNombre { get; set; } 
        public string PrimerApellido { get; set; } 
        public string? SegundoApellido { get; set; } 

    }
}
