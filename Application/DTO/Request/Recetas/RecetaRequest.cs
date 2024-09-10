namespace Application.DTO.Request.Recetas
{
    public class RecetaRequest
    {
        public string NombreReceta { get;  set; } = string.Empty;
        public string ModoPreparacion { get;  set; }=string.Empty;
        public int IdTipoReceta { get;  set; }
        public List<IngredienteRequest> Ingredientes { get; set; } =new List<IngredienteRequest>();
    }
}
