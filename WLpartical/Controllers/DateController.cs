using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WLpartical.Models;
using WLpartical.Services;

namespace WLpartical.Controllers
{
    public class DateController : Controller
    {
        private readonly HolidayService _holidayService;

        public DateController(HolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        public IActionResult Index()
        {
            return View(new DateRange());
        }

        //send DateFrom and DateTo as arguments o get working days
        [HttpPost]
        public async Task<IActionResult> CalculateDateDifference(DateRange model)
        {
            if (ModelState.IsValid)
            {
                int workingDays = await _holidayService.CalWorkDates(model.DateFrom, model.DateTo);
                model.DateDifference = workingDays;
            }

            return View("Index", model);
        }



    }
}
