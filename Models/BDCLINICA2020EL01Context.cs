using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBClinica_EL01.Models
{
    public partial class BDCLINICA2020EL01Context : DbContext
    {
        public BDCLINICA2020EL01Context()
        {
        }

        public BDCLINICA2020EL01Context(DbContextOptions<BDCLINICA2020EL01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("tu cadena de conexion a sql server");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.Nrocita)
                    .HasName("pk_nrocita");

                entity.Property(e => e.Nrocita)
                    .HasColumnName("nrocita")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codmed)
                    .HasColumnName("codmed")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Codpac)
                    .HasColumnName("codpac")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasColumnName("descrip")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate()+(1))");

                entity.Property(e => e.Pago)
                    .HasColumnName("pago")
                    .HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.CodmedNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.Codmed)
                    .HasConstraintName("fk_citas_codmed");

                entity.HasOne(d => d.CodpacNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.Codpac)
                    .HasConstraintName("fk_citas_codpac");
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.HasKey(e => e.Codmed)
                    .HasName("pk_codmed");

                entity.Property(e => e.Codmed)
                    .HasColumnName("codmed")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AnioColegio).HasColumnName("anio_colegio");

                entity.Property(e => e.Coddis)
                    .HasColumnName("coddis")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Codesp)
                    .HasColumnName("codesp")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nommed)
                    .HasColumnName("nommed")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.Codpac)
                    .HasName("pk_codpac");

                entity.Property(e => e.Codpac)
                    .HasColumnName("codpac")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Coddis)
                    .HasColumnName("coddis")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dirpac)
                    .HasColumnName("dirpac")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dnipac)
                    .HasColumnName("dnipac")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nompac)
                    .IsRequired()
                    .HasColumnName("nompac")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelCel)
                    .HasColumnName("tel_cel")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
