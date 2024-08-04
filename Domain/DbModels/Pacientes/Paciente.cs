using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
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
        public void AddPadecimiento(int  Idpadecimiento)
        {
            if (Idpadecimiento != 0)
            {
                var pacientePadecimiento = new PacientePadecimiento
                {
                    IdPaciente = this.IdPaciente,
                    IdPadecimiento = Idpadecimiento,
                };
                _pacientePadecimientos.Add(pacientePadecimiento);
            }       
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
