using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WLpartical.Models;

namespace WLpartical.Repository
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly WaterlilyContext _context;
        private readonly IMemoryCache _cache;

        public HolidayRepository(WaterlilyContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        // asnyc methodfor get all users  from db and convert to list it and cahching it for 5 minutes
        public async Task <IEnumerable<Holiday>> GetAll()
        {
            return await _cache.GetOrCreateAsync("AllHolidays", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return await _context.Holidays.ToListAsync();
            });
            

        }

    
    }
}
