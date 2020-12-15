using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Identificacion = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    ClaveIngreso = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Identificacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
