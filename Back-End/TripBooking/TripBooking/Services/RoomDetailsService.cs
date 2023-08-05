using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Services
{
    public class RoomDetailsService : IRoomDetailsService
    {
        private readonly ICrud<RoomDetails, IdDTO> _RoomDetailsRepository;
        private readonly ICrud<RoomType, IdDTO> _RoomTypeRepository;
        private readonly ICrud<Hotel, IdDTO> _hotelRepository;



        public RoomDetailsService(ICrud<RoomDetails, IdDTO> RoomDetailsMasterRepository,
            ICrud<RoomType, IdDTO> RoomTypeRepo, ICrud<Hotel, IdDTO> hotelMasterRepository)
        {
            _RoomDetailsRepository = RoomDetailsMasterRepository;
            _RoomTypeRepository=RoomTypeRepo;
            _hotelRepository = hotelMasterRepository;
        }

        public async Task<List<RoomDetails>?> Add_RoomDetails(List<RoomDetails> RoomDetailsMaster)
        {

            List<RoomDetails> addedRoomDetailsMaster = new List<RoomDetails>();

            var RoomDetailsMasters = await _RoomDetailsRepository.GetAll();

            foreach (var roomDetailsMaster in RoomDetailsMaster)
            {

                Console.WriteLine(roomDetailsMaster);

                var myRoomDetailsMaster = await _RoomDetailsRepository.Add(roomDetailsMaster);

                if (myRoomDetailsMaster != null)
                {
                    addedRoomDetailsMaster.Add(myRoomDetailsMaster);
                }

            }
            return addedRoomDetailsMaster;

        }

        public async Task<List<RoomDetails>?> Get_All_RoomDetails()
        {
            var RoomDetailsMasters = await _RoomDetailsRepository.GetAll();
            return RoomDetailsMasters;

        }

        public async Task<List<RoomdetailsDTO>> getRoomDetailsByHotel(IdDTO id)
        {
            var RoomDetailsMasters = await _RoomDetailsRepository.GetAll();
            var RoomTypes = await _RoomTypeRepository.GetAll();
            var Hotel = await _hotelRepository.GetAll();

            var query = (from hm in Hotel
                        join rd in RoomDetailsMasters on hm.Id equals rd.HotelId
                        join rt in RoomTypes on rd.RoomTypeId equals rt.Id
                        where hm.Id == id.IdInt
                        select new RoomdetailsDTO
                        {
                            RoomDetailsMasterId= rd.Id,
                            Price=rd.Price,
                            Description=rd.Description,
                            RoomType=rt.RoomTypes,

                        }).ToList();
            return query;



        }
    }
}
