using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Pacientes
{
    public class PacienteContactoRequest
    {
        public string Ocupacion { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public int Telefono { get; set; }
        public decimal GastoSemanal { get; set; }
    }
}
