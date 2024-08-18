using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModels
{
    public class Recetas
    {
        //Tipos de receta Vegetariana,baja en grasas, Oriental, Definicion 

        public Guid IdReceta { get; private set; }
        public int IdTipoReceta { get; private set; }
        public IReadOnlyList<Ingrediente> Ingredientes => _ingredientes.AsReadOnly();
        private List<Ingrediente> _ingredientes;
        public TipoReceta? TipoRecetaNav { get;  set; }

        public Recetas()
        {

        }
        public Recetas( 
            int idTipoReceta
            )
        {
            IdTipoReceta = idTipoReceta;
            IdReceta = Guid.NewGuid();
            _ingredientes = new();
        }
        public void AddIngrediente(Ingrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
        }
    }
}
