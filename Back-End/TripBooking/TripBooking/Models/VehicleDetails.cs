using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class VehicleDetails
{
    public int Id { get; set; }

    public int? VehicleId { get; set; }

    public decimal? CarPrice { get; set; }

    public int? PlaceId { get; set; }

    public string? VehicleImagepath { get; set; }

    public virtual Place? Place { get; set; }

    public virtual Vehicle? Vehicle { get; set; }

    public virtual ICollection<VehicleBooking> VehicleBookings { get; set; } = new List<VehicleBooking>();
}
