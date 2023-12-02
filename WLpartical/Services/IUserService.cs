using System.Threading.Tasks;
using WLpartical.Models;

namespace WLpartical.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
