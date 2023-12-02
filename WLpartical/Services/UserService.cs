using System.Threading.Tasks;
using WLpartical.Models;
using WLpartical.Repositories;

namespace WLpartical.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // call repositary method to get all users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }



        // call repositary method to get specific user details
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }


        // call repositary method to create new user

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.AddUserAsync(user);
        }


        // call repositary method to update specific user 
        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }


        // call repositary method to delete specific user 
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.RemoveUserAsync(id);
        }
    }
}
