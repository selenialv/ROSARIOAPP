using Microsoft.EntityFrameworkCore.Migrations;

namespace ROSARIOAPP.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "turno",
                table: "matricula",
                unicode: false,
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cedula",
                table: "estudiante",
                unicode: false,
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tutor",
                table: "estudiante",
                unicode: false,
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "turno",
                table: "matricula");

            migrationBuilder.DropColumn(
                name: "cedula",
                table: "estudiante");

            migrationBuilder.DropColumn(
                name: "tutor",
                table: "estudiante");
        }
    }
}
