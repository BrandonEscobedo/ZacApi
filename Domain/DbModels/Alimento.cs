﻿using Domain.Enums;

namespace Domain.DbModels
{
    public class Alimento
    {

        public int? IdAlimento { get; private set; }
        public int Cantidad { get; private set; }
        public int IdCategoria { get; private set; }
        public Unidad Unidad { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public CategoriaAlimento? categoriaAlimentoNav { get; set; }
        public List<Ingrediente>? IngredienteNav { get; set; }    
        public Alimento(int cantidad, int idCategoria, Unidad unidad, string nombre)
        {
            Cantidad = cantidad;
            IdCategoria = idCategoria;
            Unidad = unidad;
            Nombre = nombre;
        }
        public Alimento()
        {
            
        }
    }
}
