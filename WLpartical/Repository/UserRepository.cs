using System.Threading.Tasks;
using WLpartical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace WLpartical.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WaterlilyContext _context;
        private readonly IMemoryCache _cache;

        public UserRepository(WaterlilyContext context,IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // async method for get all users from db and convert to list
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        //get specifi user from db according to id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        //add user to db and save 
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //update existing user and save
        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        //remove existing user and save 
        public async Task<bool> RemoveUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
