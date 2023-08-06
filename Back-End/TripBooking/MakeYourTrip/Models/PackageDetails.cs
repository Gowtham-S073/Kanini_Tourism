using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class PackageDetails
{
    public int Id { get; set; }

    public int? PackageId { get; set; }

    public int? PlaceId { get; set; }

    public int? DayNumber { get; set; }

    public string? PlaceImagepath { get; set; }

    public string? Itinerary { get; set; }

    public virtual Package? Package { get; set; }

    public virtual Place? Place { get; set; }
}
