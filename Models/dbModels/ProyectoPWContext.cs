using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Primeruso.Models.dbModels
{
    public partial class ProyectoPWContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
    {
        public ProyectoPWContext()
        {
        }

        public ProyectoPWContext(DbContextOptions<ProyectoPWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; } = null!;
        public virtual DbSet<Habitacion> Habitacions { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservacions { get; set; } = null!;
        public virtual DbSet<TipoDeHabitacione> TipoDeHabitaciones { get; set; } = null!;
        public virtual DbSet<TipoDePago> TipoDePagos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.IdComentario).ValueGeneratedNever();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Usuario");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.Property(e => e.IdHabitacion).ValueGeneratedNever();

                entity.HasOne(d => d.IdHotelNavigation)
                    .WithMany(p => p.Habitacions)
                    .HasForeignKey(d => d.IdHotel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Habitacion_HOTEL");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.Habitacions)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Habitacion_Tipo de Habitaciones");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.IdHotel).ValueGeneratedNever();
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(e => e.IdPago).ValueGeneratedNever();

                entity.HasOne(d => d.IdReservacionNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Reservacion");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Tipo de pago1");
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.Property(e => e.IdReservacion).ValueGeneratedNever();

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_Habitacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_Usuario");
            });

            modelBuilder.Entity<TipoDeHabitacione>(entity =>
            {
                entity.Property(e => e.IdTipoHabitacion).ValueGeneratedNever();
            });

            modelBuilder.Entity<TipoDePago>(entity =>
            {
                entity.Property(e => e.IdTipoPago).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
