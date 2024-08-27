using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class Dieta
    {
       
        public Guid IdDieta { get; private set; }
        public string NombreDieta { get;private set; }
        private List<Recetas> _recetas=new();
        public IReadOnlyList<Recetas> Recetas=> _recetas.AsReadOnly();
        public Dieta(string nombreDieta)
        {
            NombreDieta = nombreDieta;
        }
        public Dieta()
        {
            
        }
       

    }
}
