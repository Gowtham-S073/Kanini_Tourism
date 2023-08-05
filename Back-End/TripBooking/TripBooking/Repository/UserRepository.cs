using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class UserRepository : ICrud<User, UserDTO>
    {
        private readonly TripBookingContext _context;
        public UserRepository(TripBookingContext context)
        {
            _context = context;
        }
        public async Task<User?> Add(User user)
        {
            try
            {
                var users = _context.Users;
                var myUser = await users.SingleOrDefaultAsync(u => u.Username == user.Username);
                if (myUser == null)
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<User?> Delete(UserDTO userDTO)
        {
            try
            {
                var users = _context.Users;
                var myUser = users.SingleOrDefault(u => u.Username == userDTO.Username);
                if (myUser != null)
                {
                    _context.Users.Remove(myUser);
                    await _context.SaveChangesAsync();
                    return myUser;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<User?> GetValue(UserDTO userDTO)
        {
            try
            {
                var users = await GetAll();
                if (users != null)
                {
                    var user = users.FirstOrDefault(u => u.Username == userDTO.Username);
                    if (user != null)
                    {
                        return user;
                    }
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<List<User>?> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users != null)
                    return users;
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<User?> Update(User user)
        {
            try
            {
                var users = await GetAll();
                if (users != null)
                {
                    var Newuser = users.FirstOrDefault(u => u.Username == user.Username);

                    if (Newuser != null)
                    {
                        Newuser.Username = user.Username != null ? user.Username : Newuser.Username;
                        Newuser.Phone = user.Phone != null ? user.Phone : Newuser.Phone;
                        Newuser.Email = user.Email != null ? user.Email : Newuser.Email;
                        Newuser.Name = user.Name != null ? user.Name : Newuser.Name;
                        Newuser.Hashkey = user.Hashkey != null ? user.Hashkey : Newuser.Hashkey;
                        Newuser.Password = user.Password != null ? user.Password : Newuser.Password;
                        Newuser.Role = user.Role != null ? user.Role : Newuser.Role;
                        Newuser.IsActive = user.IsActive;

                        _context.Users.Update(Newuser);
                        await _context.SaveChangesAsync();
                        return Newuser;
                    }
                    /* else
                         return null;*/
                }
                return null;


            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }

        }
    }
}
