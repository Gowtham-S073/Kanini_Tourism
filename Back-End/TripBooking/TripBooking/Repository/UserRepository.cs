using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripBooking.Models;
using TripBooking.Interfaces;
using Microsoft.EntityFrameworkCore;
using TripBooking.CustomExceptions;

namespace TripBooking.Repositories
{
    public class UserRepository : IUser
    {
        private readonly TripBookingContext _context;

        public UserRepository(TripBookingContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new UserNotFoundException($"User with username '{username}' not found.");
            }
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserPassword(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
