using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WLpartical.Models;
using WLpartical.Services;

namespace WLpartical.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: get method for get all user for table
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        // GET: get method for get specifi user details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: get create view
        public IActionResult Create()
        {
            return View();
        }

        // POST: post method for create new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,EmailAdress,JobPosition")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: get edit view
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: post method for save after edit user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,EmailAdress,JobPosition")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _userService.UpdateUserAsync(user);
                if (!success)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: get view for delete specific user
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: post method for delete user
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
