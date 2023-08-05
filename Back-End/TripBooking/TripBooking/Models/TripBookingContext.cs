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

    public virtual DbSet<Hotel> Hotel { get; set; }

    public virtual DbSet<PackageDetails> PackageDetails { get; set; }

    public virtual DbSet<Package> Package { get; set; }

    public virtual DbSet<Place> Place { get; set; }

    public virtual DbSet<Gallery> Gallery { get; set; }

    public virtual DbSet<RoomBooking> RoomBookings { get; set; }

    public virtual DbSet<RoomDetails> RoomDetails { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VehicleBooking> VehicleBookings { get; set; }

    public virtual DbSet<VehicleDetails> VehicleDetails { get; set; }

    public virtual DbSet<Vehicle> Vehicle { get; set; }

    /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
          => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog = TripBooking;integrated security=SSPI;TrustServerCertificate=True;");

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Entity<Booking>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__Bookings__3213E83F85A8A412");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.Feedback)
                  .HasMaxLength(500)
                  .HasColumnName("feedback");
              entity.Property(e => e.PackageId).HasColumnName("package_master_id");
              entity.Property(e => e.TotalAmount)
                  .HasColumnType("money")
                  .HasColumnName("total_amount");
              entity.Property(e => e.UserId).HasColumnName("user_id");

              entity.HasOne(d => d.Package).WithMany(p => p.Bookings)
                  .HasForeignKey(d => d.PackageId)
                  .HasConstraintName("FK__Bookings__packag__5AEE82B9");

              entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("FK__Bookings__user_i__59FA5E80");
          });

          modelBuilder.Entity<Hotel>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__HotelMas__3213E83FB3B09C74");

              entity.ToTable("HotelMaster");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.HotelImagepath).IsUnicode(false);
              entity.Property(e => e.HotelName)
                  .HasMaxLength(50)
                  .HasColumnName("hotel_name");
              entity.Property(e => e.PlaceId).HasColumnName("place_id");

              entity.HasOne(d => d.Place).WithMany(p => p.Hotel)
                  .HasForeignKey(d => d.PlaceId)
                  .HasConstraintName("FK__HotelMast__place__412EB0B6");
          });

          modelBuilder.Entity<PackageDetails>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__PackageD__3213E83FC313EA01");

              entity.ToTable("PackageDetailsMaster");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.DayNumber).HasColumnName("day_number");
              entity.Property(e => e.Itinerary).IsUnicode(false);
              entity.Property(e => e.PackageId).HasColumnName("package_id");
              entity.Property(e => e.PlaceId).HasColumnName("place_id");
              entity.Property(e => e.PlaceImagepath).IsUnicode(false);

              entity.HasOne(d => d.Package).WithMany(p => p.PackageDetails)
                  .HasForeignKey(d => d.PackageId)
                  .HasConstraintName("FK__PackageDe__packa__4F7CD00D");

              entity.HasOne(d => d.Place).WithMany(p => p.PackageDetails)
                  .HasForeignKey(d => d.PlaceId)
                  .HasConstraintName("FK__PackageDe__place__5070F446");
          });

          modelBuilder.Entity<Package>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__PackageM__3213E83F7CAED9F6");

              entity.ToTable("PackageMaster");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.Imagepath).IsUnicode(false);
              entity.Property(e => e.PackageName)
                  .HasMaxLength(50)
                  .HasColumnName("package_name");
              entity.Property(e => e.PackagePrice)
                  .HasColumnType("money")
                  .HasColumnName("package_price");
              entity.Property(e => e.Region).HasMaxLength(20);
              entity.Property(e => e.TravelAgentId).HasColumnName("travel_agent_id");

              entity.HasOne(d => d.TravelAgent).WithMany(p => p.Package)
                  .HasForeignKey(d => d.TravelAgentId)
                  .HasConstraintName("FK__PackageMa__trave__4BAC3F29");
          });

          modelBuilder.Entity<Place>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__PlaceMas__3213E83F7302372E");

              entity.ToTable("PlaceMaster");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.PlaceName)
                  .HasMaxLength(50)
                  .HasColumnName("place_name");
          });

          modelBuilder.Entity<Gallery>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__PostGall__3213E83F80541D78");

              entity.ToTable("PostGallery");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.AdminId).HasColumnName("admin_id");
              entity.Property(e => e.AdminImage)
                  .IsUnicode(false)
                  .HasColumnName("AdminImage");
              entity.Property(e => e.ImageType)
                  .HasMaxLength(20)
                  .IsUnicode(false)
                  .HasColumnName("image_type");

              entity.HasOne(d => d.Admin).WithMany(p => p.Gallery)
                  .HasForeignKey(d => d.AdminId)
                  .HasConstraintName("FK__PostGalle__admin__70DDC3D8");
          });

          modelBuilder.Entity<RoomBooking>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__RoomBook__3213E83FF45F08CF");

              entity.ToTable("RoomBooking");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.BookingId).HasColumnName("booking_id");
              entity.Property(e => e.RoomDetailsId).HasColumnName("room_details_id");

              entity.HasOne(d => d.Booking).WithMany(p => p.RoomBookings)
                  .HasForeignKey(d => d.BookingId)
                  .HasConstraintName("FK__RoomBooki__booki__628FA481");

              entity.HasOne(d => d.RoomDetails).WithMany(p => p.RoomBookings)
                  .HasForeignKey(d => d.RoomDetailsId)
                  .HasConstraintName("FK__RoomBooki__room___619B8048");
          });

          modelBuilder.Entity<RoomDetails>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__RoomDeta__3213E83FC22BBEAF");

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

              entity.HasOne(d => d.Hotel).WithMany(p => p.RoomDetails)
                  .HasForeignKey(d => d.HotelId)
                  .HasConstraintName("FK__RoomDetai__hotel__47DBAE45");

              entity.HasOne(d => d.RoomType).WithMany(p => p.RoomDetails)
                  .HasForeignKey(d => d.RoomTypeId)
                  .HasConstraintName("FK__RoomDetai__room___46E78A0C");
          });

          modelBuilder.Entity<RoomType>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__RoomType__3213E83F622F0467");

              entity.ToTable("RoomType");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.RoomTypes)
                  .HasMaxLength(20)
                  .HasColumnName("room_type");
          });

          modelBuilder.Entity<User>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F812DE8FB");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.Email)
                  .HasMaxLength(50)
                  .HasColumnName("email");
              entity.Property(e => e.Hashkey).HasColumnName("hashkey");
              entity.Property(e => e.IsActive).HasColumnName("isActive");
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
              entity.HasKey(e => e.Id).HasName("PK__VehicleB__3213E83FDD32CD75");

              entity.ToTable("VehicleBooking");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.BookingId).HasColumnName("booking_id");
              entity.Property(e => e.VehicleDetailsId).HasColumnName("vehicle_details_id");

              entity.HasOne(d => d.Booking).WithMany(p => p.VehicleBookings)
                  .HasForeignKey(d => d.BookingId)
                  .HasConstraintName("FK__VehicleBo__booki__5EBF139D");

              entity.HasOne(d => d.VehicleDetails).WithMany(p => p.VehicleBookings)
                  .HasForeignKey(d => d.VehicleDetailsId)
                  .HasConstraintName("FK__VehicleBo__vehic__5DCAEF64");
          });

          modelBuilder.Entity<VehicleDetails>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__VehicleD__3213E83F2166EF64");

              entity.ToTable("VehicleDetails");

              entity.Property(e => e.Id).HasColumnName("id");
              entity.Property(e => e.CarPrice)
                  .HasColumnType("money")
                  .HasColumnName("car_price");
              entity.Property(e => e.PlaceId).HasColumnName("place_id");
              entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
              entity.Property(e => e.VehicleImagepath).IsUnicode(false);

              entity.HasOne(d => d.Place).WithMany(p => p.VehicleDetails)
                  .HasForeignKey(d => d.PlaceId)
                  .HasConstraintName("FK__VehicleDe__place__571DF1D5");

              entity.HasOne(d => d.Vehicle).WithMany(p => p.VehicleDetails)
                  .HasForeignKey(d => d.VehicleId)
                  .HasConstraintName("FK__VehicleDe__vehic__5629CD9C");
          });

          modelBuilder.Entity<Vehicle>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PK__VehicleM__3213E83FDFDA7BDE");

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
  }*/
}
