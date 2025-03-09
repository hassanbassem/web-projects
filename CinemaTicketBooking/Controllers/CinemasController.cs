using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Entities;
using CinemaTicketBooking.Models.Repositories;
using CinemaTicketBooking.Models.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinemaTicketBooking.Controllers
{
    public class CinemasController : Controller
    {
        private CinemaRepository _repository;
        private IFileLoader _loader;

        public CinemasController(CinemaRepository repository, IFileLoader loader)
        {
            _repository = repository;
            _loader = loader;
        }

        public async Task<IActionResult> Cinema(int id)
        {
            return View("Cinema", await _repository.GetItemAsync(id));
        }
        
        public async Task<IActionResult> ModifyCinemas()
        {
            return View(await _repository.GetPage(9, 1));
        }

        public async Task<IActionResult> UpdateCinemaForm(int id)
        {
            Cinema cinema = await _repository.GetItemAsync(id);

            return UpdateCinemaFormWithCinemaAsAParameter(cinema);
        }

        public IActionResult UpdateCinemaFormWithCinemaAsAParameter(Cinema cinema)
        {
            ViewBag.Errors = JsonConvert.DeserializeObject<List<string>>(TempData["errors"] == null ? "" : TempData["errors"].ToString());

            return View(nameof(UpdateCinemaForm), cinema);
        }
        
        public async Task<IActionResult> UpdateCinema(int id, Cinema cinema, [Picture] IFormFile? Picture)
        {
            Cinema oldCinema = await _repository.GetItemAsync(id);


            TempData["errors"] = null;

            if (ModelState.IsValid)
            {
                cinema.Picture = _loader.Save(oldCinema.Picture, Picture, ModelState);
                await _repository.UpdateAsync(oldCinema, cinema);
                return RedirectToAction(nameof(ModifyCinemas));
            }

            TempData["errors"] = JsonConvert.SerializeObject(ModelState
                                .Values
                                .SelectMany(m => m.Errors)
                                .Select(e => e.ErrorMessage));

            return UpdateCinemaFormWithCinemaAsAParameter(cinema);
        }
    }
}
