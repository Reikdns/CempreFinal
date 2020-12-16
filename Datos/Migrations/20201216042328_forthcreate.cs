using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class forthcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaveIngreso",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "ClaveDeIngreso",
                table: "Usuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaveDeIngreso",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "ClaveIngreso",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
