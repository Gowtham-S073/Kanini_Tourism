using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IVehicleDetailservice
    {
        Task<List<VehicleDetails>?> Add_VehicleDetails(List<VehicleDetails> VehicleDetails);

        Task<List<VehicleDetails>?> Get_All_VehicleDetails();
        Task<VehicleDetails> PostImage([FromForm] VehicleFormModel vehicleFormModel);

    }
}
