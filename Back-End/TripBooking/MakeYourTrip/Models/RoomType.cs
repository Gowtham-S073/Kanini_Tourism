using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class RoomType
{
    public int Id { get; set; }

    public string? RoomTypes { get; set; }

    public virtual ICollection<RoomDetails> RoomDetails { get; set; } = new List<RoomDetails>();
}
