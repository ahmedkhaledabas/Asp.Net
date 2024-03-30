using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ETickets.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepository movieRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , IMovieRepository movieRepository)
        {
            _logger = logger;
            this.movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            return View();
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

    }
}
