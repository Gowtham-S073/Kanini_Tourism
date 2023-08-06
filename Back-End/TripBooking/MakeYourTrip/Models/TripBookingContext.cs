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

    public virtual DbSet<Booking> Booking { get; set; }

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

    }
