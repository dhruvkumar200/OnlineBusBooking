using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OBB.Data.Entities
{
    public partial class BookingDBContext : DbContext
    {
        public BookingDBContext()
        {
        }

        public BookingDBContext(DbContextOptions<BookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BusTable> BusTables { get; set; } = null!;
        public virtual DbSet<BusTypeTable> BusTypeTables { get; set; } = null!;
        public virtual DbSet<RolesTable> RolesTables { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DHRUV\\SQLEXPRESS;Database=OnlineBusBooking;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.BookedByNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookedBy)
                    .HasConstraintName("FK_Booking_UserTable");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK_Booking_BusTable");
            });

            modelBuilder.Entity<BusTable>(entity =>
            {
                entity.ToTable("BusTable");

                entity.Property(e => e.BusNo).HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RouteFrom).HasMaxLength(50);

                entity.Property(e => e.RouteTo).HasMaxLength(50);

                entity.HasOne(d => d.BusTypeNavigation)
                    .WithMany(p => p.BusTables)
                    .HasForeignKey(d => d.BusType)
                    .HasConstraintName("FK_BusTable_BusType");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BusTables)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_BusTable_UserTable");
            });

            modelBuilder.Entity<BusTypeTable>(entity =>
            {
                entity.ToTable("BusTypeTable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Types).HasMaxLength(50);
            });

            modelBuilder.Entity<RolesTable>(entity =>
            {
                entity.ToTable("RolesTable");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserRole");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("UserTable");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.PhoneNo).HasMaxLength(15);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTable_RolesTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
