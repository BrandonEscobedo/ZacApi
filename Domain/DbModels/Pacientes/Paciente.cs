using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels.Pacientes
{
    public class Paciente
    {
        public Guid IdPaciente { get; private set; }
        public EstadoPaciente Estatus { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public PacientePersonales Personales { get; private set; }
        public PacienteContacto Contacto { get; private set; }
        public PacienteSintomasAntecedentes SintomasAntecedentes { get; private set; }
        [NotMapped]
        private List<PacientePadecimiento> _pacientePadecimientos;
        [NotMapped]
        public IReadOnlyCollection<PacientePadecimiento> PacientePadecimientos => _pacientePadecimientos.AsReadOnly();
        public Paciente(PacientePersonales pacientePersonales,
            PacienteContacto pacienteContacto,
            PacienteSintomasAntecedentes sintomasAntecedentes)
        {
            IdPaciente = Guid.NewGuid();
            Personales = pacientePersonales;
            Contacto = pacienteContacto;
            SintomasAntecedentes = sintomasAntecedentes;
            Estatus = EstadoPaciente.Activo;
            FechaCreacion = DateTime.Now;
            _pacientePadecimientos = new List<PacientePadecimiento>();
        }
        public Paciente()
        {

        }
        public void AddPadecimiento(Padecimiento padecimiento)
        {
                var pacientePadecimiento = new PacientePadecimiento
                {
                    IdPaciente = this.IdPaciente,
                    IdPadecimiento = padecimiento.IdPadecimiento,
                };
                _pacientePadecimientos.Add(pacientePadecimiento);
            

        }
        public void ModificarDatosPersonales(PacientePersonales personales)
        {
            Personales = personales;
        }

        public void ModificarDatosContacto(PacienteContacto contacto)
        {
            Contacto = contacto;
        }

        public void ModificarSintomasAntecedentes(PacienteSintomasAntecedentes sintomasAntecedentes)
        {
            SintomasAntecedentes = sintomasAntecedentes;
        }
    }
}
