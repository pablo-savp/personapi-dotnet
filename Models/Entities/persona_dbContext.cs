using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace personapi_dotnet.Models.Entities
{
    public partial class persona_dbContext : DbContext
    {
        public persona_dbContext()
        {
        }

        public persona_dbContext(DbContextOptions<persona_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudio> Estudios { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Profesion> Profesions { get; set; } = null!;
        public virtual DbSet<Telefono> Telefonos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("estudios");

                entity.Property(e => e.CcPer).HasColumnName("cc_per");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdProf).HasColumnName("id_prof");

                entity.Property(e => e.Univer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("univer");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Cc);

                entity.ToTable("persona");

                entity.Property(e => e.Cc)
                    .ValueGeneratedNever()
                    .HasColumnName("cc");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("genero")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("profesion");

                entity.Property(e => e.Des)
                    .HasColumnType("text")
                    .HasColumnName("des");

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("telefono");

                entity.Property(e => e.Duenio).HasColumnName("duenio");

                entity.Property(e => e.Num)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("num");

                entity.Property(e => e.Oper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("oper");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
