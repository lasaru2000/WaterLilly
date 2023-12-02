using System.Threading.Tasks;
using WLpartical.Models;


namespace WLpartical.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> RemoveUserAsync(int id);
    }
}
