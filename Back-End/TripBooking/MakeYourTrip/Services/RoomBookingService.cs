using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Services
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly ICrud<RoomBooking, IdDTO> _RoomBookingRepo;
        public RoomBookingService(ICrud<RoomBooking, IdDTO> RoomBookingRepo)
        {
            _RoomBookingRepo = RoomBookingRepo;
        }

        public async Task<RoomBooking?> Add_RoomBooking(RoomBooking hotel)
        {
            var RoomBookingtable = await _RoomBookingRepo.GetAll();
            var newRoomBooking = RoomBookingtable?.SingleOrDefault(h => h.Id == hotel.Id);
            if (newRoomBooking == null)
            {
                var myRoomBooking = await _RoomBookingRepo.Add(hotel);
                if (myRoomBooking != null)
                    return myRoomBooking;
            }
            return null;

        }

        public async Task<List<RoomBooking>?> Get_all_RoomBooking()
        {
            var RoomBookings = await _RoomBookingRepo.GetAll();
            return RoomBookings;

        }

        public async Task<RoomBooking?> View_RoomBooking(IdDTO idDTO)
        {
            var RoomBooking = await _RoomBookingRepo.GetValue(idDTO);
            return RoomBooking;
        }
    }
}
