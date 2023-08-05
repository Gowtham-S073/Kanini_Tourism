using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using System.Security.Cryptography;
using System.Text;

namespace TripBooking.Services
{
    public class UserService : IUserService
    {
        /*        private readonly IUser _userRepo;
        */
        private readonly ICrud<User, UserDTO> _userRepo;

        private readonly ITokenGenerate _tokenService;

        public UserService(ICrud<User, UserDTO> userRepo, ITokenGenerate tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }
        public async Task<UserDTO> LogIN(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = await _userRepo.GetValue(userDTO);
            
            if (userData != null)
            {
                if (userData.IsActive == false)
                {
                    return null;
                }
                var hmac = new HMACSHA512(userData.Hashkey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.Username = userData.Username;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
                user.Name = userData.Name;
                user.Email = userData.Email;
                user.Phone = userData.Phone;
            }
            return user;
        }

        public async Task<UserDTO> Register(UserRegisterDTO userRegisterDTO)
        {
            UserDTO user = null;
            using (var hmac = new HMACSHA512())
            {
                if(userRegisterDTO.UserPassword == null)
                {
                    return null;
                }
                userRegisterDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.UserPassword));
                Console.WriteLine(userRegisterDTO.Password);
                userRegisterDTO.Hashkey = hmac.Key;
                if(userRegisterDTO.Role== "Agent")
                {
                    userRegisterDTO.IsActive = false;
                }
                var resultUser = await _userRepo.Add(userRegisterDTO);
                if (resultUser != null)
                {
                    user = new UserDTO();
                    user.Username = resultUser.Username;
                    user.Role = resultUser.Role;
                    user.Token = _tokenService.GenerateToken(user);
                }
            }
            return user;
        }


        public async Task<UserDTO> Update(UserRegisterDTO user)
        {
            var users = await _userRepo.GetAll();
            User myUser = users.SingleOrDefault(u => u.Username == user.Username);
            if (myUser != null)
            {
                myUser.Name = user.Name;
                myUser.Phone = user.Phone;
                var hmac = new HMACSHA512();
                myUser.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
                myUser.Hashkey = hmac.Key;
                myUser.Role = user.Role;
                myUser.Email = user.Email;
                UserDTO userDTO = new UserDTO();
                userDTO.Username = myUser.Username;
                userDTO.Role = myUser.Role;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
                var newUser = _userRepo.Update(myUser);
                if (newUser != null)
                {
                    return userDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<bool> Update_Password(UserDTO userDTO)
        {
            User user = new User();
            var users = await _userRepo.GetAll();
            var myUser = users.SingleOrDefault(u => u.Username == userDTO.Username);
            if (myUser != null)
            {
                var hmac = new HMACSHA512();
                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                user.Hashkey = hmac.Key;
                user.Name = myUser.Name;
                user.Role = myUser.Role;
                user.Phone = myUser.Phone;
                user.Email = myUser.Email;
                var newUser = _userRepo.Update(user);
                if (newUser != null)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<User?> ApproveAgent(User agent)
        {
            agent.IsActive= true;
            var newagent =await _userRepo.Update(agent);
            if (newagent != null)
            {
                return newagent;
            }

            return null;
        }

        public async Task<List<User>?> GetUnApprovedAgent()
        {
            var users = await _userRepo.GetAll();
            if(users != null)
            {
                var unApprovedAgent = users.Where(user => user.IsActive == false).ToList();
                return unApprovedAgent;
            }
            return null;
            

        }

        public async Task<User?> DeleteAgent(UserDTO user)
        {
            var deleteduser = await _userRepo.Delete(user);
            if (deleteduser != null)
            {
                return deleteduser;
            }
            return null;
        }
    }
}
