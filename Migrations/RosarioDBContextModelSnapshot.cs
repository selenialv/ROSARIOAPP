﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ROSARIOAPP.Models;

namespace ROSARIOAPP.Migrations
{
    [DbContext(typeof(RosarioDBContext))]
    partial class RosarioDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ROSARIOAPP.Models.Asignar", b =>
                {
                    b.Property<int>("Iddocente")
                        .HasColumnType("int");

                    b.Property<int>("Idgrupo")
                        .HasColumnType("int");

                    b.Property<short>("tutor")
                        .HasColumnType("smallint");

                    b.HasKey("Iddocente", "Idgrupo");

                    b.HasIndex("Idgrupo");

                    b.ToTable("Asignar");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Docente", b =>
                {
                    b.Property<int>("Iddocente")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Iddocente")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnName("apellidos")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Cedula")
                        .HasColumnName("cedula")
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14)
                        .IsUnicode(false);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .HasColumnName("departamento")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Direccion")
                        .HasColumnName("direccion")
                        .HasColumnType("varchar(45)")
                        .HasMaxLength(45)
                        .IsUnicode(false);

                    b.Property<string>("Nombres")
                        .HasColumnName("nombres")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Profesion")
                        .HasColumnName("profesion")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Sexo")
                        .HasColumnName("sexo")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("Telefono")
                        .HasColumnName("telefono")
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8)
                        .IsUnicode(false);

                    b.HasKey("Iddocente");

                    b.ToTable("docente");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Estudiante", b =>
                {
                    b.Property<int>("Idestudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Idestudiante")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnName("apellidos")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Departamento")
                        .HasColumnName("departamento")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Direccion")
                        .HasColumnName("direccion")
                        .HasColumnType("varchar(45)")
                        .HasMaxLength(45)
                        .IsUnicode(false);

                    b.Property<string>("Edad")
                        .HasColumnName("fecha_nac")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Nombres")
                        .HasColumnName("nombres")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Sexo")
                        .HasColumnName("sexo")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("cedula")
                        .HasColumnName("cedula")
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3)
                        .IsUnicode(false);

                    b.Property<string>("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha_nac")
                        .HasColumnName("fecha_nac1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tutor")
                        .HasColumnName("tutor")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Idestudiante");

                    b.ToTable("estudiante");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Grado", b =>
                {
                    b.Property<int>("Idgrado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Idgrado")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grado1")
                        .HasColumnName("grado")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Idgrado");

                    b.ToTable("grado");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Grupo", b =>
                {
                    b.Property<int>("Idgrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Idgrupo")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idgrado")
                        .HasColumnType("int");

                    b.Property<string>("seccion")
                        .HasColumnName("seccion")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Idgrupo");

                    b.HasIndex("Idgrado");

                    b.ToTable("grupo");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Materia", b =>
                {
                    b.Property<int>("Idmateria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Iddocente")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnName("Materia")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Idmateria");

                    b.HasIndex("Iddocente");

                    b.ToTable("materia");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Materia_Grado", b =>
                {
                    b.Property<int>("Idmateria")
                        .HasColumnType("int");

                    b.Property<int>("Idgrado")
                        .HasColumnType("int");

                    b.Property<short>("tutor")
                        .HasColumnType("smallint");

                    b.HasKey("Idmateria", "Idgrado");

                    b.HasIndex("Idgrado");

                    b.ToTable("Materia_Grado");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Matricula", b =>
                {
                    b.Property<int>("Idmatricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Idmatricula")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idestudiante")
                        .HasColumnType("int");

                    b.Property<int>("Idgrupo")
                        .HasColumnType("int");

                    b.Property<int>("Idmodalidad")
                        .HasColumnType("int");

                    b.Property<int>("año_lectivo")
                        .HasColumnName("año_lectivo")
                        .HasColumnType("int")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("estado")
                        .HasColumnName("estado")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("fecha_matricula")
                        .HasColumnName("fecha_matricula")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("observacion")
                        .HasColumnName("observacion")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("repitente")
                        .HasColumnName("repitente")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("tarjeta")
                        .HasColumnName("tarjeta")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("turno")
                        .HasColumnName("turno")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Idmatricula");

                    b.HasIndex("Idestudiante");

                    b.HasIndex("Idgrupo");

                    b.HasIndex("Idmodalidad");

                    b.ToTable("matricula");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Modalidad", b =>
                {
                    b.Property<int>("Idmodalidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Idmodalidad")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Modalidad1")
                        .HasColumnName("modalidad")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Idmodalidad");

                    b.ToTable("modalidad");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Nota", b =>
                {
                    b.Property<int>("Idnota")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Idnota")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idmateria")
                        .HasColumnType("int");

                    b.Property<string>("corte_evaluativo")
                        .HasColumnName("corte_evaluativo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("nota_final")
                        .HasColumnName("nota_final")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("parcial")
                        .HasColumnName("parcial")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Idnota");

                    b.HasIndex("Idmateria");

                    b.ToTable("nota");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Nota_Matricula", b =>
                {
                    b.Property<int>("Idnota")
                        .HasColumnType("int");

                    b.Property<int>("Idmatricula")
                        .HasColumnType("int");

                    b.HasKey("Idnota", "Idmatricula");

                    b.HasIndex("Idmatricula");

                    b.ToTable("Nota_Matricula");
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Asignar", b =>
                {
                    b.HasOne("ROSARIOAPP.Models.Docente", "docente")
                        .WithMany("Asignar")
                        .HasForeignKey("Iddocente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROSARIOAPP.Models.Grupo", "grupo")
                        .WithMany("Asignar")
                        .HasForeignKey("Idgrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Grupo", b =>
                {
                    b.HasOne("ROSARIOAPP.Models.Grado", "IdgradoNavigation")
                        .WithMany("Grupo")
                        .HasForeignKey("Idgrado")
                        .HasConstraintName("FK__Grupo__Idgrado")
                        .IsRequired();
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Materia", b =>
                {
                    b.HasOne("ROSARIOAPP.Models.Docente", "IddocenteNavigation")
                        .WithMany("Materia")
                        .HasForeignKey("Iddocente")
                        .HasConstraintName("FK__Materia__Iddocente")
                        .IsRequired();
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Materia_Grado", b =>
                {
                    b.HasOne("ROSARIOAPP.Models.Grado", "Grado")
                        .WithMany("Materia_Grado")
                        .HasForeignKey("Idgrado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROSARIOAPP.Models.Materia", "materia")
                        .WithMany("Materia_Grado")
                        .HasForeignKey("Idmateria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Matricula", b =>
                {
                    b.HasOne("ROSARIOAPP.Models.Estudiante", "IdestudianteNavigation")
                        .WithMany("Matricula")
                        .HasForeignKey("Idestudiante")
                        .HasConstraintName("FK__matricula__Idestudiante")
                        .IsRequired();

                    b.HasOne("ROSARIOAPP.Models.Grupo", "IdgrupoNavigation")
                        .WithMany("Matricula")
                        .HasForeignKey("Idgrupo")
                        .HasConstraintName("FK__matricula__Idgrupo")
                        .IsRequired();

                    b.HasOne("ROSARIOAPP.Models.Modalidad", "IdmodalidadNavigation")
                        .WithMany("Matricula")
                        .HasForeignKey("Idmodalidad")
                        .HasConstraintName("FK__matricula__Idmodalidad")
                        .IsRequired();
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Nota", b =>
                {
                    b.HasOne("ROSARIOAPP.Models.Materia", "IdmateriaNavigation")
                        .WithMany("Nota")
                        .HasForeignKey("Idmateria")
                        .HasConstraintName("FK__nota__Idmateria")
                        .IsRequired();
                });

            modelBuilder.Entity("ROSARIOAPP.Models.Nota_Matricula", b =>
                {
                    b.HasOne("ROSARIOAPP.Models.Matricula", "Matricula")
                        .WithMany("Nota_Matricula")
                        .HasForeignKey("Idmatricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ROSARIOAPP.Models.Nota", "Nota")
                        .WithMany("Nota_Matricula")
                        .HasForeignKey("Idnota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
