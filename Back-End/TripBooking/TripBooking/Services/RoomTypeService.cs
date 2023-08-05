using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;

namespace TripBooking.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly ICrud<RoomType, IdDTO> _RoomTypeRepository;
        public RoomTypeService(ICrud<RoomType, IdDTO> RoomTypeRepo)
        {
            _RoomTypeRepository = RoomTypeRepo;
        }

        public async Task<RoomType?> Add_RoomType(RoomType RoomType)
        {
            var palcemastertable = await _RoomTypeRepository.GetAll();
            var newpalcemaster = palcemastertable?.SingleOrDefault(h => h.Id == RoomType.Id);
            if (newpalcemaster == null)
            {
                var mypalcemaster = await _RoomTypeRepository.Add(RoomType);
                if (mypalcemaster != null)
                    return mypalcemaster;
            }
            return null;

        }
        public async Task<List<RoomType>?> Get_all_RoomType()
        {
            var RoomTypes = await _RoomTypeRepository.GetAll();
            return RoomTypes;

        }

    }
}
