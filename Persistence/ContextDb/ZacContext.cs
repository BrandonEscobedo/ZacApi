using Microsoft.EntityFrameworkCore;
using Domain.DbModels;
using Domain.DbModels.Pacientes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace Persistence.ContextDb
{
    public partial class ZacContext : DbContext
    {
        public virtual DbSet<CategoriaAlimento> CategoriaAlimentos { get; set; }
        public virtual DbSet<Alimento> Alimentos { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<PacientePersonales> PacientePersonales { get; set; }
        public virtual DbSet<PacienteContacto> PacienteContacto { get; set; }
        public virtual DbSet<PacienteSintomasAntecedentes> PacienteSintomasAntecedentes { get; set; }
        public virtual DbSet<Padecimiento> Padecimientos { get; set; }
        public virtual DbSet<PacientePadecimiento> PacientePadecimientos { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<TipoReceta> TipoRecetas { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public ZacContext(DbContextOptions<ZacContext> options)
            :base(options)
        {        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var dateTimeConverter= new ValueConverter<DateTime, DateTime>(v=>v.ToUniversalTime(), v=>DateTime.SpecifyKind(v, DateTimeKind.Utc));
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                }
            }
                builder.Entity<PacienteContacto>(entity =>
            {
                entity.Property(x => x.Correo).HasMaxLength(256);
                entity.Property(x => x.GastoSemanal).HasColumnType("decimal(10,2)");
                entity.Property(x => x.Ocupacion).HasMaxLength(50);
            });
            builder.Entity<PacientePersonales>(entity =>
            {
                entity.Property(x => x.Nombres).HasMaxLength(50);
                entity.Property(x => x.Apellido).HasMaxLength(50);
                entity.Property(x => x.Genero).HasConversion<string>();
                entity.Property(x => x.Genero).HasMaxLength(10);
            });
            builder.Entity<Paciente>(entity =>
            {
                entity.HasKey(x => x.IdPaciente);

                entity.HasOne(x => x.Personales)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<PacientePersonales>(x => x.IdPaciente)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(x => x.Contacto)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<PacienteContacto>(x => x.IdPaciente)
                    .OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(x => x.SintomasAntecedentes)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<PacienteSintomasAntecedentes>(x => x.IdPaciente)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(x => x.Estatus).HasConversion<string>();
            });
           
            builder.Entity<Alimento>(entity =>
            {
                entity.HasKey(x => x.IdAlimento);
                entity.Property(x=>x.IdAlimento).ValueGeneratedOnAdd();
                entity.HasOne(x => x.categoriaAlimentoNav)
                .WithMany(x => x.AlimentosNav)
                .HasForeignKey(x => x.IdCategoria);
                entity.Property(x => x.Nombre).HasMaxLength(60);
                entity.Property(x => x.Unidad).HasConversion<string>();
                entity.Property(x => x.Unidad).HasMaxLength(15);
            });
            builder.Entity<CategoriaAlimento>(entity =>
            {
                entity.HasKey(x => x.IdCategoriaAlimento);
                entity.Property(x=>x.IdCategoriaAlimento).ValueGeneratedOnAdd(); 
                entity.Property(x => x.Categoria).HasMaxLength(20);
                entity.HasIndex(x => x.Categoria).IsUnique();
                entity.Property(x => x.Descripcion)
                .HasColumnType("text");
            });
            builder.Entity<PacientePadecimiento>(entity =>
            {
                entity.HasKey(p => new {p.IdPaciente,p.IdPadecimiento});

                entity.HasOne(x=>x.Paciente)
                .WithMany(p=>p.PacientePadecimientos)
                .HasForeignKey(p=>p.IdPaciente);

                entity.HasOne(x => x.Padecimiento)
                .WithMany(x => x.PacientePadecimientos)
                .HasForeignKey(x => x.IdPadecimiento);

            });
            builder.Entity<Padecimiento>(entity =>
            {
                entity.HasKey(p => p.IdPadecimiento);
                entity.Property(p => p.IdPadecimiento).ValueGeneratedOnAdd();
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Descripcion).HasMaxLength(500);
                entity.HasIndex(p => p.Nombre).IsUnique();
            });
            builder.Entity<Ingrediente>(entity =>
            {
                entity.HasKey(x => x.IdIngrediente);
                entity.Property(x => x.TipoIngrediente).HasConversion<string>();
                entity.Property(x => x.TipoIngrediente).HasMaxLength(30);
                entity.HasOne(x => x.AlimentoNav)
                .WithMany(x => x.IngredienteNav)
                .HasForeignKey(x => x.IdAlimento);
            });
            builder.Entity<TipoReceta>(entity =>
            {
                entity.HasKey(x => x.IdTipoReceta);
                entity.Property(x => x.NombreReceta).HasMaxLength(60);
                entity.HasIndex(x => x.NombreReceta).IsUnique();
            });
            builder.Entity<Receta>(entity =>
            {
                entity.HasKey(x => x.IdReceta);

                entity.HasOne(x => x.TipoRecetaNav)
                .WithMany(x => x.Recetas)
                .HasForeignKey(x => x.IdTipoReceta);

                entity.HasMany(x => x.Ingredientes)
                .WithOne(x => x.RecetaNav)
                .HasForeignKey(x => x.IdReceta);
                entity.Property(x => x.NombreReceta).HasMaxLength(50);
            });
        }
    }
}
