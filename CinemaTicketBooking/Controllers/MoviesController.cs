using CinemaTicketBooking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers
{
    public class MoviesController : Controller
    {
        private MovieRepository _repository;

        public MoviesController(MovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int pageNo)
        {
            return View("Movies", await _repository.GetPage(9, pageNo));
        }

        public async Task<IActionResult> Movie(int id)
        {
            return View("MovieDetails", await _repository.GetItemAsync(id));
        }
    }
}
