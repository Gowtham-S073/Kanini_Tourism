using TripBooking.Models;
using TripBooking.Models.DTO;

namespace TripBooking.Interfaces
{
    public interface IRoomDetailsService
    {
        Task<List<RoomDetails>?> Add_RoomDetails(List<RoomDetails> RoomDetails);

        Task<List<RoomDetails>?> Get_All_RoomDetails();
        Task<List<RoomdetailsDTO>> getRoomDetailsByHotel(IdDTO id);
    }
}
