using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CausaViva.Models;

public partial class CausaVivaContext : DbContext
{
    public CausaVivaContext()
    {
    }

    public CausaVivaContext(DbContextOptions<CausaVivaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<EstadoPostulante> EstadoPostulantes { get; set; }

    public virtual DbSet<InscripcionVoluntariado> InscripcionVoluntariados { get; set; }

    public virtual DbSet<Organizacion> Organizacions { get; set; }

    public virtual DbSet<RequisitosVoluntariado> RequisitosVoluntariados { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Voluntariado> Voluntariados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CausaViva;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDistrito).HasName("PK__Distrito__DE8EED590F822F3E");

            entity.ToTable("Distrito");

            entity.Property(e => e.NombreDistrito).HasMaxLength(100);
        });

        modelBuilder.Entity<EstadoPostulante>(entity =>
        {
            entity.HasKey(e => e.IdEstadoP).HasName("PK__EstadoPo__C7C71E014FB4154C");

            entity.ToTable("EstadoPostulante");

            entity.Property(e => e.EstadoP).HasMaxLength(100);
        });

        modelBuilder.Entity<InscripcionVoluntariado>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("PK__Inscripc__A122F2BFCB69A9AD");

            entity.ToTable("InscripcionVoluntariado");

            entity.Property(e => e.FechaInscripcion).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasMaxLength(20);

            entity.HasOne(d => d.IdEstadoPNavigation).WithMany(p => p.InscripcionVoluntariados)
                .HasForeignKey(d => d.IdEstadoP)
                .HasConstraintName("FK__Inscripci__IdEst__5EBF139D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.InscripcionVoluntariados)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Inscripci__IdUsu__5CD6CB2B");

            entity.HasOne(d => d.IdVoluntariadoNavigation).WithMany(p => p.InscripcionVoluntariados)
                .HasForeignKey(d => d.IdVoluntariado)
                .HasConstraintName("FK__Inscripci__IdVol__5DCAEF64");
        });

        modelBuilder.Entity<Organizacion>(entity =>
        {
            entity.HasKey(e => e.IdOrganizacion).HasName("PK__Organiza__07D4D8390F766339");

            entity.ToTable("Organizacion");

            entity.Property(e => e.IdOrganizacion).HasMaxLength(11);
            entity.Property(e => e.Contrasenia).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.RazonSocial).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(100);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Organizacions)
                .HasForeignKey(d => d.IdDistrito)
                .HasConstraintName("FK__Organizac__IdDis__52593CB8");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Organizacions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Organizac__IdRol__5165187F");
        });

        modelBuilder.Entity<RequisitosVoluntariado>(entity =>
        {
            entity.HasKey(e => e.IdRequisitos).HasName("PK__Requisit__BDA0C5017BE94689");

            entity.ToTable("RequisitosVoluntariado");

            entity.Property(e => e.Descripcion).HasMaxLength(800);

            entity.HasOne(d => d.IdVoluntariadoNavigation).WithMany(p => p.RequisitosVoluntariados)
                .HasForeignKey(d => d.IdVoluntariado)
                .HasConstraintName("FK__Requisito__IdVol__5812160E");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C411C982C");

            entity.Property(e => e.DescripcionRol).HasMaxLength(200);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97F5CB5FB5");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasMaxLength(20);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contrasenia).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(100);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDistrito)
                .HasConstraintName("FK__Usuario__IdDistr__4E88ABD4");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__4D94879B");
        });

        modelBuilder.Entity<Voluntariado>(entity =>
        {
            entity.HasKey(e => e.IdVoluntariado).HasName("PK__Voluntar__92B8DECF6BA2B66A");

            entity.ToTable("Voluntariado");

            entity.Property(e => e.DescripcionPropuesta).HasMaxLength(300);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.FechaFinal).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.IdOrganizacion).HasMaxLength(11);
            entity.Property(e => e.TituloPropuesta).HasMaxLength(100);

            entity.HasOne(d => d.IdOrganizacionNavigation).WithMany(p => p.Voluntariados)
                .HasForeignKey(d => d.IdOrganizacion)
                .HasConstraintName("FK__Voluntari__IdOrg__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
