using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IPackageDetailsService
    {
        Task<List<PackageDetails>?> Add_PackageDetails(List<PackageDetails> PackageDetails);

        Task<List<PackageDetails>?> Get_All_PackageDetails();

        Task<PackageDetails> PostImage([FromForm] PlaceFormModel placeFormModel);

    }
}
