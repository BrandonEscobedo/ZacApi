using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DbModels;
using System.Text;
using System.Threading.Tasks;
using Domain.DbModels.Pacientes;
using System.Reflection.Emit;

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
        public ZacContext(DbContextOptions<ZacContext> options)
            :base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PacienteContacto>(entity =>
            {
                entity.Property(x => x.Correo).HasMaxLength(256);
                entity.Property(x => x.GastoSemanal).HasColumnType("decimal(10,2)");
                entity.Property(x => x.Ocupacion).HasMaxLength(50);
            });
            builder.Entity<PacientePersonales>(entity =>
            {
                entity.Property(x => x.PrimerNombre).HasMaxLength(20);
                entity.Property(x => x.SegundoNombre).HasMaxLength(20);
                entity.Property(x => x.PrimerApellido).HasMaxLength(20);
                entity.Property(x => x.SegundoApellido).HasMaxLength(20);
                entity.Property(x => x.Genero).HasConversion<string>();
            });
            builder.Entity<Paciente>(entity =>
            {
                entity.HasKey(x => x.IdPaciente);

                entity.HasOne(x => x.Personales)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<PacientePersonales>(x => x.IdPaciente).OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(x => x.Contacto)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<PacienteContacto>(x => x.IdPaciente).OnDelete(DeleteBehavior.Cascade); ;
                entity.HasOne(x => x.SintomasAntecedentes)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<PacienteSintomasAntecedentes>(x => x.IdPaciente).OnDelete(DeleteBehavior.Cascade);
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
                entity.HasKey(p => p.IdPacientePadecimiento);
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
            });

        }
    }
}
