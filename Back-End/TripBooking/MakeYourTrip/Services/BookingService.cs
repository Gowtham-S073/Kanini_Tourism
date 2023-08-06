using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly ICrud<Booking, IdDTO> _BookingRepo;
        public BookingService(ICrud<Booking, IdDTO> BookingRepo)
        {
            _BookingRepo = BookingRepo;
        }

        public async Task<Booking?> Add_Booking(Booking hotel)
        {
            var Bookingtable = await _BookingRepo.GetAll();
            var newBooking = Bookingtable?.SingleOrDefault(h => h.Id == hotel.Id);
            if (newBooking == null)
            {
                var myBooking = await _BookingRepo.Add(hotel);
                if (myBooking != null)
                    return myBooking;
            }
            return null;

        }

        public async Task<List<Booking>?> Get_All_Booking()
        {
            var Bookings = await _BookingRepo.GetAll();
            return Bookings;

        }

        public async Task<Booking?> View_Booking(IdDTO idDTO)
        {
            var Booking = await _BookingRepo.GetValue(idDTO);
            return Booking;
        }
    }
}
