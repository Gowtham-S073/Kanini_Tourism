using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class RoomBooking
{
    public int Id { get; set; }

    public int? RoomDetailsId { get; set; }

    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual RoomDetails? RoomDetails { get; set; }
}
