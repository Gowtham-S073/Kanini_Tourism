using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IImageRepo<T, K>
    {
        Task<T> PostImage([FromForm] K formodel);
    }
}
