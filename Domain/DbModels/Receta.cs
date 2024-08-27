using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbModels
{
    public class Receta
    {
        public Guid IdReceta { get; private set; }
        public string NombreReceta { get; private set; }
        public string ModoPreparacion { get; private set; }
        public int IdTipoReceta { get; private set; }
        public IReadOnlyList<Ingrediente> Ingredientes => _ingredientes.AsReadOnly();
        [NotMapped]
        private List<Ingrediente> _ingredientes = [];
        public TipoReceta? TipoRecetaNav { get; set; }

        public Receta()
        {

        }
        public Receta(
            int idTipoReceta,
            string modoPreparacion,
            string nombreReceta
            )
        {
            NombreReceta = nombreReceta;
            ModoPreparacion = modoPreparacion;
            IdTipoReceta = idTipoReceta;
            IdReceta = Guid.NewGuid();
        }
        public void AddIngrediente(Ingrediente ingrediente)
        {
            if(ingrediente.IdIngrediente!=Guid.Empty)
            {
            _ingredientes.Add(ingrediente);
            }
        }
    }
}
