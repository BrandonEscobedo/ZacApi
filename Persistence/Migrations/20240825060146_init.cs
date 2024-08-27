using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaAlimentos",
                columns: table => new
                {
                    IdCategoriaAlimento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Categoria = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaAlimentos", x => x.IdCategoriaAlimento);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<Guid>(type: "uuid", nullable: false),
                    Estatus = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Padecimientos",
                columns: table => new
                {
                    IdPadecimiento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padecimientos", x => x.IdPadecimiento);
                });

            migrationBuilder.CreateTable(
                name: "TipoRecetas",
                columns: table => new
                {
                    IdTipoReceta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreReceta = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRecetas", x => x.IdTipoReceta);
                });

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    IdAlimento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false),
                    Unidad = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.IdAlimento);
                    table.ForeignKey(
                        name: "FK_Alimentos_CategoriaAlimentos_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriaAlimentos",
                        principalColumn: "IdCategoriaAlimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteContacto",
                columns: table => new
                {
                    IdPaciente = table.Column<Guid>(type: "uuid", nullable: false),
                    Ocupacion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Telefono = table.Column<int>(type: "integer", nullable: false),
                    GastoSemanal = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteContacto", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_PacienteContacto_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacientePersonales",
                columns: table => new
                {
                    IdPaciente = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Genero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<short>(type: "smallint", nullable: false),
                    Nombres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientePersonales", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_PacientePersonales_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteSintomasAntecedentes",
                columns: table => new
                {
                    IdPaciente = table.Column<Guid>(type: "uuid", nullable: false),
                    Signos = table.Column<string>(type: "text", nullable: true),
                    Sintomas = table.Column<string>(type: "text", nullable: true),
                    AntecedentesFamiliares = table.Column<string>(type: "text", nullable: true),
                    AntecedentesPersonales = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteSintomasAntecedentes", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_PacienteSintomasAntecedentes_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacientePadecimientos",
                columns: table => new
                {
                    IdPaciente = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPadecimiento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientePadecimientos", x => new { x.IdPaciente, x.IdPadecimiento });
                    table.ForeignKey(
                        name: "FK_PacientePadecimientos_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientePadecimientos_Padecimientos_IdPadecimiento",
                        column: x => x.IdPadecimiento,
                        principalTable: "Padecimientos",
                        principalColumn: "IdPadecimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    IdReceta = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreReceta = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModoPreparacion = table.Column<string>(type: "text", nullable: false),
                    IdTipoReceta = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.IdReceta);
                    table.ForeignKey(
                        name: "FK_Recetas_TipoRecetas_IdTipoReceta",
                        column: x => x.IdTipoReceta,
                        principalTable: "TipoRecetas",
                        principalColumn: "IdTipoReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IdIngrediente = table.Column<Guid>(type: "uuid", nullable: false),
                    IdAlimento = table.Column<int>(type: "integer", nullable: false),
                    IdReceta = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoIngrediente = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    UnidadesTotales = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IdIngrediente);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Alimentos_IdAlimento",
                        column: x => x.IdAlimento,
                        principalTable: "Alimentos",
                        principalColumn: "IdAlimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Recetas_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Recetas",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_IdCategoria",
                table: "Alimentos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaAlimentos_Categoria",
                table: "CategoriaAlimentos",
                column: "Categoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_IdAlimento",
                table: "Ingredientes",
                column: "IdAlimento");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_IdReceta",
                table: "Ingredientes",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_PacientePadecimientos_IdPadecimiento",
                table: "PacientePadecimientos",
                column: "IdPadecimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Padecimientos_Nombre",
                table: "Padecimientos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_IdTipoReceta",
                table: "Recetas",
                column: "IdTipoReceta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "PacienteContacto");

            migrationBuilder.DropTable(
                name: "PacientePadecimientos");

            migrationBuilder.DropTable(
                name: "PacientePersonales");

            migrationBuilder.DropTable(
                name: "PacienteSintomasAntecedentes");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Padecimientos");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "CategoriaAlimentos");

            migrationBuilder.DropTable(
                name: "TipoRecetas");
        }
    }
}
