using TripBooking.Interfaces;
using TripBooking.Models;
using TripBooking.Models.DTO;
using TripBooking.Repos;

namespace TripBooking.Services
{
    public class PlaceService: IPlaceService
    {
        private readonly ICrud<Place, IdDTO> _placeRepository;
        public PlaceService(ICrud<Place, IdDTO> placemasterRepo)
        {
            _placeRepository= placemasterRepo;
        }

        public async Task<Place?> Add_Place(Place placeMaster)
        {
            var palcemastertable = await _placeRepository.GetAll();
            var newpalcemaster = palcemastertable?.SingleOrDefault(h => h.Id == placeMaster.Id);
            if (newpalcemaster == null)
            {
                var mypalcemaster = await _placeRepository.Add(placeMaster);
                if (mypalcemaster != null)
                    return mypalcemaster;
            }
            return null;

        }
        public async Task<List<Place>?> Get_All_Place()
        {
            var Place = await _placeRepository.GetAll();
            return Place;

        }

        public async Task<Place?> Delete_Place(IdDTO idDTO)
        {
            var placeMaster = await _placeRepository.Delete(idDTO);
            return placeMaster;
        }


    }
}
