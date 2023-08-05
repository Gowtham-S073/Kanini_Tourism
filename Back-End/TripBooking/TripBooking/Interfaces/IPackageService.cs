using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IPackageService
    {
        Task<Package?> Add_PackageDetails(Package PackageMaster);

        Task<List<Package>?> Get_All_PackageDetails();
        Task<Package?> View_Package(IdDTO idDTO);

        Task<PackageDTO?> Get_Package_Details(IdDTO id);

        Task<Package> PostDashboardImage([FromForm] PackageFormModel packageFormModel);


    }
}
