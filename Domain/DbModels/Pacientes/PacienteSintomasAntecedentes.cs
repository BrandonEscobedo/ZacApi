using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels.Pacientes
{
    //[table] Cambiar nombre de tabla en EF
    public class PacienteSintomasAntecedentes
    {
        [Key]
        public Guid IdPacienteSintomas { get;  set; }
        public Guid IdPaciente { get; set; }
        public Paciente Paciente { get; set; }

        //Convertir a text en Ef para postgreSQL
        public string? Signos { get; set; }
        public string? Sintomas { get; set; }
        public string? AntecedentesFamiliares { get; set; }
        public string? AntecedentesPersonales { get; set; }

    }
}
