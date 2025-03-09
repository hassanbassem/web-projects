using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;

namespace CinemaTicketBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewData.Add("mo", 11);
            ViewBag.mo2 = 12; 
            return View();
        }

        public IActionResult SetTempData()
        {
            TempData["mo"] = "mo salah";

            return Content("done");
        }

        public IActionResult get1() 
        {
            return Content("get1 " + (string)TempData["mo"]);
        }
        
        public IActionResult get2() 
        {
            return Content("get2 " + (string)TempData["mo"]);
        }

        public IActionResult setSession()
        {
            HttpContext.Session.SetString("mo", "mo salah");

            return Content("done");
        }

        public IActionResult error404()
        {
            return Content("error 404!!!!!!!!!!");
        }

        public IActionResult getSession()
        {
            return Content(HttpContext.Session.GetString("mo").ToString());
        }

        public IActionResult SetCookies() 
        {
            HttpContext.Response.Cookies.Append("mo", "mo salah", new CookieBuilder { Expiration = TimeSpan.FromDays(2) }.Build(HttpContext));

            return Content("done");
        }

        public IActionResult GetCookies()
        {
            return Content(HttpContext.Request.Cookies.ToJson());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult trial()
        {
            User mo = new User { FName = "mo", LName = "salah", Email = "mosalah", UserName = "mosalah", Password = "mosalah" };
            _db.Users.Add(mo);

            _db.Orders.Add(new Order { User = mo });

            _db.SaveChanges();

            Order orderToDelete = _db.Orders.FirstOrDefault();

            _db.Orders.Remove(orderToDelete);

            _db.SaveChanges();

            return Content("done");
        }
    }
}