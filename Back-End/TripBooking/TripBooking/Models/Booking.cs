using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PackageId { get; set; }

    public string? Feedback { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Package? Package { get; set; }

    public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();

    public virtual User? User { get; set; }

    public virtual ICollection<VehicleBooking> VehicleBookings { get; set; } = new List<VehicleBooking>();
}
