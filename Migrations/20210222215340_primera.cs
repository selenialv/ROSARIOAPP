using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROSARIOAPP.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "docente",
                columns: table => new
                {
                    Iddocente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    apellidos = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    sexo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    cedula = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    departamento = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ciudad = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    telefono = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    profesion = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    direccion = table.Column<string>(unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docente", x => x.Iddocente);
                });

            migrationBuilder.CreateTable(
                name: "estudiante",
                columns: table => new
                {
                    Idestudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(nullable: true),
                    nombres = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    apellidos = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    fecha_nac1 = table.Column<DateTime>(nullable: false),
                    fecha_nac = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    sexo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    departamento = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ciudad = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    direccion = table.Column<string>(unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiante", x => x.Idestudiante);
                });

            migrationBuilder.CreateTable(
                name: "grado",
                columns: table => new
                {
                    Idgrado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grado = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grado", x => x.Idgrado);
                });

            migrationBuilder.CreateTable(
                name: "modalidad",
                columns: table => new
                {
                    Idmodalidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modalidad = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modalidad", x => x.Idmodalidad);
                });

            migrationBuilder.CreateTable(
                name: "materia",
                columns: table => new
                {
                    Idmateria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iddocente = table.Column<int>(nullable: false),
                    Materia = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materia", x => x.Idmateria);
                    table.ForeignKey(
                        name: "FK__Materia__Iddocente",
                        column: x => x.Iddocente,
                        principalTable: "docente",
                        principalColumn: "Iddocente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    Idgrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idgrado = table.Column<int>(nullable: false),
                    seccion = table.Column<int>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.Idgrupo);
                    table.ForeignKey(
                        name: "FK__Grupo__Idgrado",
                        column: x => x.Idgrado,
                        principalTable: "grado",
                        principalColumn: "Idgrado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materia_Grado",
                columns: table => new
                {
                    Idgrado = table.Column<int>(nullable: false),
                    Idmateria = table.Column<int>(nullable: false),
                    tutor = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia_Grado", x => new { x.Idmateria, x.Idgrado });
                    table.ForeignKey(
                        name: "FK_Materia_Grado_grado_Idgrado",
                        column: x => x.Idgrado,
                        principalTable: "grado",
                        principalColumn: "Idgrado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materia_Grado_materia_Idmateria",
                        column: x => x.Idmateria,
                        principalTable: "materia",
                        principalColumn: "Idmateria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nota",
                columns: table => new
                {
                    Idnota = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idmateria = table.Column<int>(nullable: false),
                    parcial = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    corte_evaluativo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    nota_final = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nota", x => x.Idnota);
                    table.ForeignKey(
                        name: "FK__nota__Idmateria",
                        column: x => x.Idmateria,
                        principalTable: "materia",
                        principalColumn: "Idmateria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asignar",
                columns: table => new
                {
                    Idasignar = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iddocente = table.Column<int>(nullable: false),
                    Idgrupo = table.Column<int>(nullable: false),
                    tutor = table.Column<short>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignar", x => x.Idasignar);
                    table.ForeignKey(
                        name: "FK__asignar_Iddocente",
                        column: x => x.Iddocente,
                        principalTable: "docente",
                        principalColumn: "Iddocente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__asignar__Idgrupo",
                        column: x => x.Idgrupo,
                        principalTable: "grupo",
                        principalColumn: "Idgrupo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    Idmatricula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idestudiante = table.Column<int>(nullable: false),
                    Idmodalidad = table.Column<int>(nullable: false),
                    Idgrupo = table.Column<int>(nullable: false),
                    año_lectivo = table.Column<int>(nullable: false),
                    fecha_matricula = table.Column<DateTime>(nullable: false),
                    estado = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    tarjeta = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    estado1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.Idmatricula);
                    table.ForeignKey(
                        name: "FK__matricula__Idestudiante",
                        column: x => x.Idestudiante,
                        principalTable: "estudiante",
                        principalColumn: "Idestudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__matricula__Idgrupo",
                        column: x => x.Idgrupo,
                        principalTable: "grupo",
                        principalColumn: "Idgrupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__matricula__Idmodalidad",
                        column: x => x.Idmodalidad,
                        principalTable: "modalidad",
                        principalColumn: "Idmodalidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nota_Matricula",
                columns: table => new
                {
                    Idnota = table.Column<int>(nullable: false),
                    Idmatricula = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota_Matricula", x => new { x.Idnota, x.Idmatricula });
                    table.ForeignKey(
                        name: "FK_Nota_Matricula_matricula_Idmatricula",
                        column: x => x.Idmatricula,
                        principalTable: "matricula",
                        principalColumn: "Idmatricula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Matricula_nota_Idnota",
                        column: x => x.Idnota,
                        principalTable: "nota",
                        principalColumn: "Idnota",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asignar_Iddocente",
                table: "asignar",
                column: "Iddocente");

            migrationBuilder.CreateIndex(
                name: "IX_asignar_Idgrupo",
                table: "asignar",
                column: "Idgrupo");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_Idgrado",
                table: "grupo",
                column: "Idgrado");

            migrationBuilder.CreateIndex(
                name: "IX_materia_Iddocente",
                table: "materia",
                column: "Iddocente");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_Grado_Idgrado",
                table: "Materia_Grado",
                column: "Idgrado");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_Idestudiante",
                table: "matricula",
                column: "Idestudiante");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_Idgrupo",
                table: "matricula",
                column: "Idgrupo");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_Idmodalidad",
                table: "matricula",
                column: "Idmodalidad");

            migrationBuilder.CreateIndex(
                name: "IX_nota_Idmateria",
                table: "nota",
                column: "Idmateria");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_Matricula_Idmatricula",
                table: "Nota_Matricula",
                column: "Idmatricula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asignar");

            migrationBuilder.DropTable(
                name: "Materia_Grado");

            migrationBuilder.DropTable(
                name: "Nota_Matricula");

            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "nota");

            migrationBuilder.DropTable(
                name: "estudiante");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "modalidad");

            migrationBuilder.DropTable(
                name: "materia");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "docente");
        }
    }
}
