using System.Threading.Tasks;
using TripBooking.Models;

namespace TripBooking.Interfaces
{
    public interface IUser
    {
        Task<User> GetUserById(int userId);
        Task<User> GetUserByUsername(string username);
        Task<User> 
        Task<User> LogIn(User user);
        Task<User> Update (UserRegisterDTO user);
        Task<bool> UpdateUserPassword(User user);
    }
}
    