using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMonedas.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialCrediticio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    RNCEmpresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConceptoDeuda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCrediticio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicesInflacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periodo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Indice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicesInflacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaludFinanciera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indicador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MontoTotalAdeudado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaludFinanciera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasasCambio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moneda = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Tasa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasasCambio", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialCrediticio");

            migrationBuilder.DropTable(
                name: "IndicesInflacion");

            migrationBuilder.DropTable(
                name: "SaludFinanciera");

            migrationBuilder.DropTable(
                name: "TasasCambio");
        }
    }
}
