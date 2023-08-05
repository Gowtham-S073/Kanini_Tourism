using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IPlaceService

    {
        Task<Place?> Add_Place(Place Place);

        Task<List<Place>?> Get_All_Place();

        Task<Place?> Delete_Place(IdDTO idDTO);

    }
}
