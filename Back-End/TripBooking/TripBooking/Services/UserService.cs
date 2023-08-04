using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripBooking.Models;
using TripBooking.DTO;
using TripBooking.Interfaces;
using TripBooking.CustomExceptions;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TripBooking.Repositories;

namespace TripBooking.Services
{
    public class UserService : IUser
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with ID '{userId}' not found.");
            }

            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new UserNotFoundException($"User with username '{username}' not found.");
            }

            return user;
        }

        public async Task<User> AddUser(UserDTO userDto)
        {
            var existingUser = await _userRepository.GetUserByUsername(userDto.Username);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException($"Username '{userDto.Username}' already exists.");
            }

            using (var hmac = new HMACSHA512())
            {
                var newUser = new User
                {
                    Username = userDto.Username,
                    Phone = userDto.Phone,
                    Email = userDto.Email,
                    Name = userDto.Name,
                    Hashkey = hmac.Key,
                    Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
                    Role = userDto.Role
                };

                await _userRepository.AddUser(newUser);
                return newUser;
            }
        }

        public async Task<User> UpdateUser(UserDTO userDto)
        {
            var user = await _userRepository.GetUserById(userDto.Id);
            if (user == null)
            {
                throw new UserNotFoundException($"User with ID '{userDto.Id}' not found.");
            }

            user.Name = userDto.Name;
            user.Phone = userDto.Phone;
            user.Email = userDto.Email;

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                using (var hmac = new HMACSHA512(user.Hashkey))
                {
                    user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
                }
            }

            await _userRepository.UpdateUser(user);
            return user;
        }

        public async Task<bool> UpdateUserPassword(int userId, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with ID '{userId}' not found.");
            }

            using (var hmac = new HMACSHA512(user.Hashkey))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(oldPassword));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.Password[i])
                    {
                        throw new InvalidPasswordException("Invalid old password.");
                    }
                }

                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(newPassword));
            }

            return await _userRepository.UpdateUserPassword(user);
        }

        private UserDTO MapToUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}
