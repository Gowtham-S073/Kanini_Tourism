using TripBooking.Models;

namespace TripBooking.Interfaces
{
    public interface IRoomTypeService
    {
        Task<RoomType?> Add_RoomType(RoomType RoomType);

        Task<List<RoomType>?> Get_all_RoomType();
    }
}
