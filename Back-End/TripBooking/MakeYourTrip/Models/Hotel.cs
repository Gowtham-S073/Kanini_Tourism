using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string? HotelName { get; set; }

    public int? PlaceId { get; set; }

    public string? HotelImagepath { get; set; }

    public virtual Place? Place { get; set; }

    public virtual ICollection<RoomDetails> RoomDetails { get; set; } = new List<RoomDetails>();
}
