namespace Domain.DbModels
{
    public class CategoriaAlimento
    {
        public int? IdCategoriaAlimento { get; private set; }
        public string Categoria { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public CategoriaAlimento(string categoria, string descripcion)
        {
            Categoria = categoria;
           Descripcion = descripcion;
        }

        public ICollection<Alimento>? AlimentosNav { get; set; }
    }
}
