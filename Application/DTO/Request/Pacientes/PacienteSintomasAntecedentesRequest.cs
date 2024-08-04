using Domain.DbModels.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Pacientes
{
    public class PacienteSintomasAntecedentesRequest
    {

        public string? Signos { get; set; }
        public string? Sintomas { get; set; }
        public string? AntecedentesFamiliares { get; set; }
        public string? AntecedentesPersonales { get; set; }
    }
}
