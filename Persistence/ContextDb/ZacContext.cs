using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DbModels;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ContextDb
{
    public partial class ZacContext : DbContext
    {
        public virtual DbSet<CategoriaAlimento> CategoriaAlimentos { get; set; }
        public virtual DbSet<Alimento> Alimentos { get; set; }
        public ZacContext(DbContextOptions<ZacContext> options)
            :base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Alimento>(entity =>
            {
                entity.HasKey(x => x.IdAlimento);
                entity.HasOne(x => x.categoriaAlimentoNav)
                .WithMany(x => x.AlimentosNav)
                .HasForeignKey(x => x.IdAlimento);
                entity.Property(x => x.Nombre).HasMaxLength(60);
                entity.Property(x => x.Unidad).HasConversion<string>();
            });
            builder.Entity<CategoriaAlimento>(entity =>
            {
                entity.HasKey(x => x.IdCategoriaAlimento);
                entity.Property(x => x.Categoria).HasMaxLength(20);
                entity.HasIndex(x => x.Categoria).IsUnique();
                entity.Property(x => x.Descripcion)
                .HasColumnType("text");
            });
        }
    }
}
