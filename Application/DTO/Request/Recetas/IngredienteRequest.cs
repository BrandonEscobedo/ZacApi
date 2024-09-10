using Domain.Enums;

namespace Application.DTO.Request.Recetas
{
    public class IngredienteRequest
    {
        public int IdAlimento { get;  set; }
        public string TipoIngrediente { get; set; } = string.Empty;
        public  TipoIngrediente TipoIngredienteEnum { get;  set; }

        public int UnidadesTotales { get;  set; }
    }
}
