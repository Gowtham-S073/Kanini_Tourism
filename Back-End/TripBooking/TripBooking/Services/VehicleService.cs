using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ICrud<Vehicle, IdDTO> _VehicleMasterRepo;
        public VehicleService(ICrud<Vehicle, IdDTO> VehicleMasterRepo)
        {
            _VehicleMasterRepo = VehicleMasterRepo;
        }

        public async Task<Vehicle?> Add_Vehicle(Vehicle VehicleMaster)
        {
            var palcemastertable = await _VehicleMasterRepo.GetAll();
            var newpalcemaster = palcemastertable?.SingleOrDefault(h => h.Id == VehicleMaster.Id);
            if (newpalcemaster == null)
            {
                var mypalcemaster = await _VehicleMasterRepo.Add(VehicleMaster);
                if (mypalcemaster != null)
                    return mypalcemaster;
            }
            return null;

        }
        public async Task<List<Vehicle>?> Get_all_VehicleMaster()
        {
            var VehicleMasters = await _VehicleMasterRepo.GetAll();
            return VehicleMasters;

        }

        public async Task<Vehicle?> View_VehicleMaster(IdDTO idDTO)
        {
            var VehicleMaster = await _VehicleMasterRepo.GetValue(idDTO);
            return VehicleMaster;
        }
    }
}
