using TripBooking.Models.DTO;

namespace TripBooking.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);

    }
}
