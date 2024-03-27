using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ETickets.Controllers
{
    public class HomeController : Controller
    {
        ETicketsDbContext Context = new ETicketsDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Context.Movies.Include(e=>e.Category).Include(e=>e.Cinema).ToList());
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

        //searchItem like movieName
        public IActionResult Search(string searchItem)
        {
            var SearchItems = Context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .Where(m=>m.Name.Contains( searchItem)).ToList();
            return View("Index", SearchItems);
        }
    }
}
