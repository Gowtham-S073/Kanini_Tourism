using TripBooking.Interfaces;
using TripBooking.Models;
using TripBooking.Models.DTO;
using TripBooking.Repos;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Services
{
    public class HotelService: IHotelService
    {
        private readonly ICrud<Hotel, IdDTO> _hotelRepository;
        private readonly IImageRepo<Hotel, HotelFormModule> _imageRepo;

        public HotelService(ICrud<Hotel, IdDTO> hotelMasterRepository, IImageRepo<Hotel, HotelFormModule> imageRepo)
        {
            _hotelRepository = hotelMasterRepository;
            _imageRepo = imageRepo;
        }

        public async Task<Hotel?> Add_Hotel(Hotel hotel)
        {
            var hotelMastertable = await _hotelRepository.GetAll();
            var newHotel = hotelMastertable?.SingleOrDefault(h => h.Id == hotel.Id);
            if (newHotel == null)
            {
                var myHotel = await _hotelRepository.Add(hotel);
                if (myHotel != null)
                    return myHotel;
            }
            return null;

        }

        public async Task<List<Hotel>?> Get_All_Hotel()
        {
            var Hotel = await _hotelRepository.GetAll();
            return Hotel;

        }

        public async Task<Hotel?> View_Hotel(IdDTO idDTO)
        {
            var HotelMaster = await _hotelRepository.GetValue(idDTO);
            return HotelMaster;
        }

        public async Task<Hotel> PostImage([FromForm] HotelFormModule hotelFormModule)
        {
            if (hotelFormModule == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(hotelFormModule);
            if(item == null)
            {
                return null;
            }
            return item;
        }
    }
}
