using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class RoomDetails
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public int? RoomTypeId { get; set; }

    public int? HotelId { get; set; }

    public string? Description { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();

    public virtual RoomType? RoomType { get; set; }
}
