using CinemaTicketBooking.Models.Entities;
using CinemaTicketBooking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers
{
    public class UsersController : Controller
    {
        private UserRepository _repository;

        public UsersController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(User user)
        {
            if (user.FName == null) 
            {
                return View("CreateAccountForm", user);
            }

            await _repository.AddAsync(user);

            return RedirectToAction("index", "movies", new { pageNo = 1 });
        } 
        public IActionResult CreateAccountForm()
        {
            return View();
        }

        public async Task<IActionResult> EditUserForm(int id)
        {
            return View("CreateAccountForm", await _repository.GetItemAsync(id));
        }

        public IActionResult EditUser(User user)
        {
            //_repository.UpdateAsync(user);

            return Content("done");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
