using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> Add_Booking(Booking newHotel);
        Task<List<Booking>?> Get_All_Booking();
        Task<Booking?> View_Booking(IdDTO idDTO);
    }
}
