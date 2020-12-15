using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HojasDeVida",
                columns: table => new
                {
                    IdHojaDeVida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(nullable: true),
                    FechaDeSolicitud = table.Column<DateTime>(nullable: false),
                    Programa = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    LugarDeNacimiento = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<string>(nullable: true),
                    DireccionActual = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    EpsActual = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    CiudadActual = table.Column<string>(nullable: true),
                    EstudiosRealizados = table.Column<string>(nullable: true),
                    Idiomas = table.Column<string>(nullable: true),
                    ProyectosRealizados = table.Column<string>(nullable: true),
                    ConocimientoPracticaInformatica = table.Column<string>(nullable: true),
                    SeminarioYCursosAsistidos = table.Column<string>(nullable: true),
                    DistincionesYHonoresRecibidos = table.Column<string>(nullable: true),
                    ExperienciaLaboral = table.Column<string>(nullable: true),
                    AreasDeInteresParaPracticas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojasDeVida", x => x.IdHojaDeVida);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojasDeVida");
        }
    }
}
