using CinemaTicketBooking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers
{
    public class ActorsController : Controller
    {
        private ActorRepository _repository;

        public ActorsController(ActorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Actor(int id)
        {
            return View("Views/Artists/Artist.cshtml", await _repository.GetItemAsync(id));
        }
    }
}
