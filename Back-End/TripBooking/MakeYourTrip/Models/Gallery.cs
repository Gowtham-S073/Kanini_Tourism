using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class Gallery
{
    public int Id { get; set; }

    public int? AdminId { get; set; }

    public string? AdminImage { get; set; }

    public string? ImageType { get; set; }

    public virtual User? Admin { get; set; }
}
