using Microsoft.EntityFrameworkCore.Migrations;

namespace ROSARIOAPP.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado1",
                table: "matricula");

            migrationBuilder.AlterColumn<string>(
                name: "fecha_matricula",
                table: "matricula",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "observacion",
                table: "matricula",
                unicode: false,
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "repitente",
                table: "matricula",
                unicode: false,
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "observacion",
                table: "matricula");

            migrationBuilder.DropColumn(
                name: "repitente",
                table: "matricula");

            migrationBuilder.AlterColumn<string>(
                name: "fecha_matricula",
                table: "matricula",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "estado1",
                table: "matricula",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
