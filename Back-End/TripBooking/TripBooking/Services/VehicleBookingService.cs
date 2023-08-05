using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Services
{
    public class VehicleBookingService : IVehicleBookingService
    {
        private readonly ICrud<VehicleBooking, IdDTO> _VehicleBookingRepo;
        public VehicleBookingService(ICrud<VehicleBooking, IdDTO> VehicleBookingRepo)
        {
            _VehicleBookingRepo = VehicleBookingRepo;
        }

        public async Task<VehicleBooking?> Add_VehicleBooking(VehicleBooking hotel)
        {
            var VehicleBookingtable = await _VehicleBookingRepo.GetAll();
            var newVehicleBooking = VehicleBookingtable?.SingleOrDefault(h => h.Id == hotel.Id);
            if (newVehicleBooking == null)
            {
                var myVehicleBooking = await _VehicleBookingRepo.Add(hotel);
                if (myVehicleBooking != null)
                    return myVehicleBooking;
            }
            return null;

        }

        public async Task<List<VehicleBooking>?> Get_All_VehicleBooking()
        {
            var VehicleBookings = await _VehicleBookingRepo.GetAll();
            return VehicleBookings;

        }

        public async Task<VehicleBooking?> View_VehicleBooking(IdDTO idDTO)
        {
            var VehicleBooking = await _VehicleBookingRepo.GetValue(idDTO);
            return VehicleBooking;
        }
    }
}
