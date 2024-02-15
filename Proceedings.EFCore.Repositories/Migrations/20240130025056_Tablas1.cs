using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proceedings.EFCore.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Tablas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(50)", maxLength: 9, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 200, nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(100)", maxLength: 200, nullable: true),
                    CP = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Poblacion = table.Column<string>(type: "nvarchar(100)", maxLength: 200, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 200, nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(100)", maxLength: 200, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 200, nullable: true),
                    Bandera_img_Path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nacionalidad_img = table.Column<byte[]>(type: "image", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 12, nullable: true),
                    Movil = table.Column<string>(type: "nvarchar(100)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAccess = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    ExpedienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnyoExpediente = table.Column<int>(type: "int", nullable: false),
                    NumeroExpediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CP = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Poblacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bandera_img_Path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bandera_img = table.Column<byte[]>(type: "image", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Movil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Importe = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ImporteBase = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ImporteIVA = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ImporteRET = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ImporteTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UserAccess = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.ExpedienteID);
                    table.ForeignKey(
                        name: "FK_Expedientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expedientes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_ClienteId",
                table: "Expedientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_DepartamentoId",
                table: "Expedientes",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departamentos_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departamentos_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "AspNetUsers");
        }
    }
}
