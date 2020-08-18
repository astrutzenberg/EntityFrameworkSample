using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ActiveServicesEntity
{
    public partial class ActiveServicesContext : DbContext
    {
        public ActiveServicesContext()
        {
        }

        public ActiveServicesContext(DbContextOptions<ActiveServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hosts> Hosts { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceMessage> ServiceMessage { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "as_owner");

            modelBuilder.Entity<Hosts>(entity =>
            {
                entity.Property(e => e.Hostname)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ServiceMessage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.ServiceMessage)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceMessage_Host");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceMessage)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceMessage_Service");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
