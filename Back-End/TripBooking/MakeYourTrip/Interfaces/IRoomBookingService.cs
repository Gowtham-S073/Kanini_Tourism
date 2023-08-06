using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Interfaces
{
    public interface IRoomBookingService
    {
        Task<RoomBooking?> Add_RoomBooking(RoomBooking newHotel);
        Task<List<RoomBooking>?> Get_all_RoomBooking();
        Task<RoomBooking?> View_RoomBooking(IdDTO idDTO);
    }
}
