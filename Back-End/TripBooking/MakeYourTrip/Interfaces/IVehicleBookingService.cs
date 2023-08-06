using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Interfaces
{
    public interface IVehicleBookingService
    {
        Task<VehicleBooking?> Add_VehicleBooking(VehicleBooking newHotel);
        Task<List<VehicleBooking>?> Get_All_VehicleBooking();
        Task<VehicleBooking?> View_VehicleBooking(IdDTO idDTO);
    }
}
