using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ROSARIOAPP.Models
{
    public partial class RosarioDBContext : DbContext
    {
        public RosarioDBContext()
        {
        }

        public RosarioDBContext(DbContextOptions<RosarioDBContext> options)
            : base(options)
        {
        }
       
        public virtual DbSet<Docente> Docente { get; set; }

        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Modalidad> Modalidad { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Materia_Grado> Materia_Grado { get; set; }
        public virtual DbSet<Nota_Matricula> Nota_Matricula { get; set; }

        public virtual DbSet<Asignar> Asignar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=LAPTOP-QQ4CDATD\\SQLEXPRESS; DataBase=dbRosario; User Id=sa; Password= root");

                //optionsBuilder.UseSqlServer("Server=DESKTOP-DQ3S4N5\\SQLEXPRESS; DataBase=RosarioDB; User Id=sa; Password= root");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Nota_Matricula>()
                 .HasKey(e => new { e.Idnota, e.Idmatricula });

            modelBuilder.Entity<Nota_Matricula>()
         .HasOne(e => e.Nota)
         .WithMany(n => n.Nota_Matricula)
         .HasForeignKey(e => e.Idnota);

            modelBuilder.Entity<Nota_Matricula>()
                .HasOne(e => e.Matricula)
                .WithMany(m => m.Nota_Matricula)
                .HasForeignKey(e => e.Idmatricula);



            modelBuilder.Entity<Materia_Grado>()
                 .HasKey(e => new { e.Idmateria, e.Idgrado });

 

            modelBuilder.Entity<Materia_Grado>()
         .HasOne(e => e.materia)
         .WithMany(n => n.Materia_Grado)

         .HasForeignKey(e => e.Idmateria);
            modelBuilder.Entity<Materia_Grado>()
                .HasOne(e => e.Grado)
                .WithMany(m => m.Materia_Grado)
                .HasForeignKey(e => e.Idgrado);
     


            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.Iddocente);
                entity.Property(e => e.Iddocente)
                    .HasColumnName("Iddocente");

                entity.ToTable("docente");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Profesion)
                    .HasColumnName("profesion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante);
          
                entity.ToTable("estudiante");

                entity.Property(e => e.Idestudiante)
                    .HasColumnName("Idestudiante");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("codigo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Edad)
                    .HasColumnName("edad")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Edad)
                  .HasColumnName("fecha_nac")
                  .HasMaxLength(10)
                  .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

              
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.Idgrado);
                entity.Property(e => e.Idgrado)
                .HasColumnName("Idgrado");

                entity.ToTable("grado");

                entity.Property(e => e.Grado1)
                    .HasColumnName("grado")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Idgrupo);
                entity.Property(e => e.Idgrupo)
                .HasColumnName("Idgrupo");

                entity.ToTable("grupo");

                entity.Property(e => e.seccion)
                    .HasColumnName("seccion")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdgradoNavigation)
            .WithMany(p => p.Grupo)
            .HasForeignKey(d => d.Idgrado)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Grupo__Idgrado");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.Idmateria);
                

                entity.ToTable("materia");


                entity.Property(e => e.Nombre)
                    .HasColumnName("Materia")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddocenteNavigation)
                .WithMany(p => p.Materia)
                .HasForeignKey(d => d.Iddocente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Materia__Iddocente");


            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.Idmatricula);


                entity.Property(e => e.Idmatricula)
              .HasColumnName("Idmatricula");
                entity.ToTable("matricula");


                entity.Property(e => e.repitente)
                    .HasColumnName("año_lectivo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.repitente)
                    .HasColumnName("fecha_matricula")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.repitente)
                    .HasColumnName("repitente")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.tarjeta)
                    .HasColumnName("tarjeta")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.repitente)
                    .HasColumnName("estado")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.Idestudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__Idestudiante");

                entity.HasOne(d => d.IdgrupoNavigation)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.Idgrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__Idgrupo");

                entity.HasOne(d => d.IdmodalidadNavigation)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.Idmodalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__Idmodalidad");


            });

            modelBuilder.Entity<Modalidad>(entity =>
            {
                entity.HasKey(e => e.Idmodalidad);
                entity.Property(e => e.Idmodalidad)
                  .HasColumnName("Idmodalidad");

                entity.ToTable("modalidad");

                entity.Property(e => e.Modalidad1)
                    .HasColumnName("modalidad")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(e => e.Idnota);
                entity.Property(e => e.Idnota)
                 .HasColumnName("Idnota");

                entity.ToTable("nota");

                entity.Property(e => e.parcial)
                    .HasColumnName("parcial")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.corte_evaluativo)
                    .HasColumnName("corte_evaluativo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.nota_final)
                    .HasColumnName("nota_final")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmateriaNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.Idmateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nota__Idmateria");
            });



            modelBuilder.Entity<Asignar>(entity =>
            {
                entity.HasKey(e => e.Idasignar);

                entity.Property(e => e.Idasignar)
                   .HasColumnName("Idasignar");
                entity.ToTable("asignar");

                entity.Property(e => e.tutor)
                  .HasColumnName("tutor")
                  .HasMaxLength(1)
                  .IsUnicode(false);

                entity.HasOne(d => d.IddocenteNavigation)
                     .WithMany(p => p.Asignar)
                     .HasForeignKey(d => d.Iddocente)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK__asignar_Iddocente");

                entity.HasOne(d => d.IdgrupoNavigation)
                  .WithMany(p => p.Asignar)
                  .HasForeignKey(d => d.Idgrupo)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__asignar__Idgrupo");
            });
    

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
