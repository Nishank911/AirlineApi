using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirlineManagementAPI.Models
{
    public partial class AirlineManagementContext : DbContext
    {
        public AirlineManagementContext()
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.ChangeTracker.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public AirlineManagementContext(DbContextOptions<AirlineManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<TicketDetails> TicketDetails { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KRBJUU5;Database=AirlineManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .HasColumnName("adminID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasColumnName("adminPassword")
                    .HasMaxLength(56)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Card__1788CCACE2052F99");

                entity.HasIndex(e => e.CardNo)
                    .HasName("UQ__Card__BDFCFDC49A1C6AFC")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CardNo)
                    .IsRequired()
                    .HasColumnName("card_No")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasColumnName("card_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Card)
                    .HasForeignKey<Card>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Card__UserID__33D4B598");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightNo)
                    .HasName("PK__Flight__8A9E3D454CD851D8");

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalTime)
                    .IsRequired()
                    .HasColumnName("Arrival_time")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DepartTime)
                    .IsRequired()
                    .HasColumnName("Depart_time")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FromLoc)
                    .IsRequired()
                    .HasColumnName("From_loc")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PriceB)
                    .HasColumnName("price_B")
                    .HasColumnType("money");

                entity.Property(e => e.PriceE)
                    .HasColumnName("price_E")
                    .HasColumnType("money");

                entity.Property(e => e.ToLoc)
                    .IsRequired()
                    .HasColumnName("To_loc")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => new { e.TicketNo, e.Seatno })
                    .HasName("PK__Passenge__EAE9D6914A7CFCDF");

                entity.Property(e => e.TicketNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Seatno)
                    .HasColumnName("seatno")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.ClassT)
                    .IsRequired()
                    .HasColumnName("classT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.TicketNoNavigation)
                    .WithMany(p => p.Passenger)
                    .HasForeignKey(d => d.TicketNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Passenger__Ticke__571DF1D5");
            });

            modelBuilder.Entity<TicketDetails>(entity =>
            {
                entity.HasKey(e => e.TicketNo)
                    .HasName("PK__TicketDe__712CCE645A9BC886");

                entity.Property(e => e.TicketNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FDeptDt)
                    .IsRequired()
                    .HasColumnName("F_dept_dt")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNo)
                    .IsRequired()
                    .HasColumnName("Flight_No")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SeatsBookedB).HasColumnName("seats_booked_B");

                entity.Property(e => e.SeatsBookedE).HasColumnName("seats_booked_E");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.FlightNoNavigation)
                    .WithMany(p => p.TicketDetails)
                    .HasForeignKey(d => d.FlightNo)
                    .HasConstraintName("FK__TicketDet__Fligh__2D27B809");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TicketDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TicketDet__UserI__2C3393D0");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__CB9A1CDFFE139339");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D105349823B458")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNo)
                    .HasName("UQ__Users__F3EE33E2C77F1A12")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .IsRequired()
                    .HasColumnName("DOB")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(56)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo).HasColumnType("decimal(10, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
