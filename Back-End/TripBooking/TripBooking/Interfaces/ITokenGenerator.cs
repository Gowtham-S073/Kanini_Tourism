using TripBooking.DTO;

namespace TripBooking.Interfaces
{
    public interface ITokenGenerator
    {
        public string GenerateToken(UserDTO user);
    }
}
