using CinemaTicketBooking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers
{
    public class ProducersController : Controller
    {
        private ProducerRepository _repository;

        public ProducersController(ProducerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Producer(int id)
        {
            return View("Views/Artists/Artist.cshtml", await _repository.GetItemAsync(id));
        }
    }
}
