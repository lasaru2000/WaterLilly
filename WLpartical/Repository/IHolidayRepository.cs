using WLpartical.Models;

namespace WLpartical.Repository
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<Holiday>> GetAll();
    }
}
