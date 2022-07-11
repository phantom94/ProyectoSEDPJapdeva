using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoSEDP.Models
{
    public partial class CrudSEDPContext : DbContext
    {
        public CrudSEDPContext()
        {
        }

        public CrudSEDPContext(DbContextOptions<CrudSEDPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competencia> Competencia { get; set; }
        public virtual DbSet<Criterio> Criterios { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<DepartamentoxUsuario> DepartamentoxUsuarios { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<PerfilxUsuario> PerfilxUsuarios { get; set; }
        public virtual DbSet<Pregunta> Pregunta { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolxUsuario> RolxUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CrudSEDP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Competencia>(entity =>
            {
                entity.HasKey(e => e.CodigoCompetencia);

                entity.Property(e => e.CodigoCompetencia).HasColumnName("codigoCompetencia");

                entity.Property(e => e.DescripcionCompetencia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcionCompetencia");

                entity.Property(e => e.NombreCompetencia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombreCompetencia");
            });

            modelBuilder.Entity<Criterio>(entity =>
            {
                entity.HasKey(e => e.CodigoCriterio);

                entity.ToTable("Criterio");

                entity.Property(e => e.CodigoCriterio).HasColumnName("codigoCriterio");

                entity.Property(e => e.DescripcionCriterio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcionCriterio");

                entity.Property(e => e.PesoCriterio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pesoCriterio");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.CodigoDepartamento);

                entity.ToTable("Departamento");

                entity.Property(e => e.CodigoDepartamento).HasColumnName("codigoDepartamento");

                entity.Property(e => e.DescripcionDepartamento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcionDepartamento");

                entity.Property(e => e.NombreDepartamento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombreDepartamento");
            });

            modelBuilder.Entity<DepartamentoxUsuario>(entity =>
            {
                entity.HasKey(e => e.CodigoDepartamentoxUsuario);

                entity.ToTable("DepartamentoxUsuario");

                entity.Property(e => e.CodigoDepartamentoxUsuario).HasColumnName("codigoDepartamentoxUsuario");

                entity.Property(e => e.CodigoDepartamento).HasColumnName("codigoDepartamento");

                entity.Property(e => e.CodigoUsuario).HasColumnName("codigoUsuario");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.CodigoPerfil);

                entity.ToTable("Perfil");

                entity.Property(e => e.CodigoPerfil).HasColumnName("codigoPerfil");

                entity.Property(e => e.DescripcionPerfil)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcionPerfil");

                entity.Property(e => e.NombrePerfil)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombrePerfil");
            });

            modelBuilder.Entity<PerfilxUsuario>(entity =>
            {
                entity.HasKey(e => e.CodigoPerfilxUsuario);

                entity.ToTable("PerfilxUsuario");

                entity.Property(e => e.CodigoPerfilxUsuario).HasColumnName("codigoPerfilxUsuario");

                entity.Property(e => e.CodigoPerfil).HasColumnName("codigoPerfil");

                entity.Property(e => e.CodigoUsuario).HasColumnName("codigoUsuario");
            });

            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.HasKey(e => e.CodigoPregunta);

                entity.Property(e => e.CodigoPregunta).HasColumnName("codigoPregunta");

                entity.Property(e => e.DescripcionPregunta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcionPregunta");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.CodigoRol);

                entity.ToTable("Rol");

                entity.Property(e => e.CodigoRol).HasColumnName("codigoRol");

                entity.Property(e => e.DescripcionRol)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcionRol");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombreRol");
            });

            modelBuilder.Entity<RolxUsuario>(entity =>
            {
                entity.HasKey(e => e.CodigoRolxUsuario);

                entity.ToTable("RolxUsuario");

                entity.Property(e => e.CodigoRolxUsuario).HasColumnName("codigoRolxUsuario");

                entity.Property(e => e.CodigoRol).HasColumnName("codigoRol");

                entity.Property(e => e.CodigoUsuario).HasColumnName("codigoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodigoUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.CodigoUsuario).HasColumnName("codigoUsuario");

                entity.Property(e => e.ContrasennaUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("contrasennaUsuario");

                entity.Property(e => e.CorreoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correoUsuario");

                entity.Property(e => e.FotoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fotoUsuario");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombreUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
