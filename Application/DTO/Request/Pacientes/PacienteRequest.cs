using Application.DTO.Request.Padecimientos;
using Domain.DbModels;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Pacientes
{
    public class PacienteRequest
    {
        public EstadoPaciente Estatus { get; private set; }

        public PacienteContactoRequest PacienteContactoRequest { get; set; } = new();
        public PacientePersonalesRequest PersonalesRequest { get; set; } = new();
        public PacienteSintomasAntecedentesRequest SintomasRequest { get;set; } = new();
        public List<PadecimientoRequest>? PadecimientosRequest { get;set; } 
    }
}
