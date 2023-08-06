using TripBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IImageListRepo
    {
        Task<List<Package>> PostPackageImages([FromForm] List<Package> Package);

    }
}
