using Microsoft.AspNetCore.Mvc;
using WLpartical.Repositories;
using WLpartical.Models;
using WLpartical.Repository;
using System.Threading.Tasks;

namespace WLpartical.Services
{
    public class HolidayService 
    {
        private readonly IHolidayRepository _holidayRepository;

        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }


        // get holiday list from reposioroy and calculation working days using a for loop to iterate over dates between From to TO
        public async Task<int> CalWorkDates(DateTime DateFrom , DateTime DateTo)
        { 
            
            int workingDays = 0;
            IEnumerable<Holiday> holidays = await _holidayRepository.GetAll();

            for (DateTime date = DateFrom; date <= DateTo; date = date.AddDays(1))
                {
                    // check if it's not a weekend
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        // check if it's a holiday
                        if (!holidays.Any(h => h.Date.Date == date.Date))
                        {
                            workingDays++;
                        }
                    }
                }
               return workingDays;
            }
        }
    }

