using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Models;

public partial class TripBookingContext : DbContext
{
    public TripBookingContext()
    {
    }

    public TripBookingContext(DbContextOptions<TripBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<HotelMaster> HotelMasters { get; set; }

    public virtual DbSet<PackageDetailsMaster> PackageDetailsMasters { get; set; }

    public virtual DbSet<PackageMaster> PackageMasters { get; set; }

    public virtual DbSet<PlaceMaster> PlaceMasters { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RoomBooking> RoomBookings { get; set; }

    public virtual DbSet<RoomDetailsMaster> RoomDetailsMasters { get; set; }

    public virtual DbSet<RoomTypeMaster> RoomTypeMasters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VehicleBooking> VehicleBookings { get; set; }

    public virtual DbSet<VehicleDetailsMaster> VehicleDetailsMasters { get; set; }

    public virtual DbSet<VehicleMaster> VehicleMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog = TripBooking; integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3213E83F951CAFD4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Feedback)
                .HasMaxLength(500)
                .HasColumnName("feedback");
            entity.Property(e => e.PackageMasterId).HasColumnName("package_master_id");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("money")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.PackageMaster).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PackageMasterId)
                .HasConstraintName("FK__Bookings__packag__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookings__user_i__656C112C");
        });

        modelBuilder.Entity<HotelMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HotelMas__3213E83FD229C4D0");

            entity.ToTable("HotelMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HotelName)
                .HasMaxLength(50)
                .HasColumnName("hotel_name");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");

            entity.HasOne(d => d.Place).WithMany(p => p.HotelMasters)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK__HotelMast__place__5070F446");
        });

        modelBuilder.Entity<PackageDetailsMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PackageD__3213E83F936431A6");

            entity.ToTable("PackageDetailsMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DayNumber)
                .HasMaxLength(10)
                .HasColumnName("day_number");
            entity.Property(e => e.PackageId).HasColumnName("package_id");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");

            entity.HasOne(d => d.Package).WithMany(p => p.PackageDetailsMasters)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__PackageDe__packa__5BE2A6F2");

            entity.HasOne(d => d.Place).WithMany(p => p.PackageDetailsMasters)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK__PackageDe__place__5CD6CB2B");
        });

        modelBuilder.Entity<PackageMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PackageM__3213E83F87DB448A");

            entity.ToTable("PackageMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PackageName)
                .HasMaxLength(50)
                .HasColumnName("package_name");
            entity.Property(e => e.PackagePrice)
                .HasColumnType("money")
                .HasColumnName("package_price");
            entity.Property(e => e.Region).HasMaxLength(20);
            entity.Property(e => e.TravelAgentId).HasColumnName("travel_agent_id");

            entity.HasOne(d => d.TravelAgent).WithMany(p => p.PackageMasters)
                .HasForeignKey(d => d.TravelAgentId)
                .HasConstraintName("FK__PackageMa__trave__59063A47");
        });

        modelBuilder.Entity<PlaceMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceMas__3213E83F051B4283");

            entity.ToTable("PlaceMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlaceName)
                .HasMaxLength(50)
                .HasColumnName("place_name");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Request__3213E83FE8BE9396");

            entity.ToTable("Request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasMaxLength(10);
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");
        });

        modelBuilder.Entity<RoomBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomBook__3213E83FBCFB6F02");

            entity.ToTable("RoomBooking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.RoomDetailsId).HasColumnName("room_details_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__RoomBooki__booki__6E01572D");

            entity.HasOne(d => d.RoomDetails).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.RoomDetailsId)
                .HasConstraintName("FK__RoomBooki__room___6D0D32F4");
        });

        modelBuilder.Entity<RoomDetailsMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomDeta__3213E83F61E20C7B");

            entity.ToTable("RoomDetailsMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

            entity.HasOne(d => d.Hotel).WithMany(p => p.RoomDetailsMasters)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__RoomDetai__hotel__5629CD9C");

            entity.HasOne(d => d.RoomType).WithMany(p => p.RoomDetailsMasters)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK__RoomDetai__room___5535A963");
        });

        modelBuilder.Entity<RoomTypeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomType__3213E83F2D4FB9C1");

            entity.ToTable("RoomTypeMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .HasColumnName("room_type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FD3413814");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Hashkey).HasColumnName("hashkey");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasMaxLength(10);
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");
        });

        modelBuilder.Entity<VehicleBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleB__3213E83F99C35AD7");

            entity.ToTable("VehicleBooking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.VehicleDetailsId).HasColumnName("vehicle_details_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.VehicleBookings)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__VehicleBo__booki__6A30C649");

            entity.HasOne(d => d.VehicleDetails).WithMany(p => p.VehicleBookings)
                .HasForeignKey(d => d.VehicleDetailsId)
                .HasConstraintName("FK__VehicleBo__vehic__693CA210");
        });

        modelBuilder.Entity<VehicleDetailsMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleD__3213E83FC7EC1101");

            entity.ToTable("VehicleDetailsMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarPrice)
                .HasColumnType("money")
                .HasColumnName("car_price");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Place).WithMany(p => p.VehicleDetailsMasters)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK__VehicleDe__place__628FA481");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.VehicleDetailsMasters)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__VehicleDe__vehic__619B8048");
        });

        modelBuilder.Entity<VehicleMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleM__3213E83F3C9A1373");

            entity.ToTable("VehicleMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NumberOfSeats).HasColumnName("number_of_seats");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(20)
                .HasColumnName("vehicle_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
