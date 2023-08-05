using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle?> Add_Vehicle(Vehicle VehicleMaster);

        Task<List<Vehicle>?> Get_all_VehicleMaster();
        Task<Vehicle?> View_VehicleMaster(IdDTO idDTO);

    }
}
