using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IHotelService
    {
        Task<Hotel?> Add_Hotel(Hotel newHotel);
        Task<List<Hotel>?> Get_All_Hotel();
        Task<Hotel?> View_Hotel(IdDTO idDTO);
        Task<Hotel> PostImage([FromForm] HotelFormModule hotelFormModule);


    }
}
