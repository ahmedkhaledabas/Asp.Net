using ETickets.Data;
using ETickets.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        ICinemaRepository cinemaRepository;

        public CinemaController(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }
      
        public IActionResult Index()
        {
            var cinemas = cinemaRepository.ReadAll();
            return View(cinemas);
        }

        public IActionResult ShowMovies(int id)
        {
            var movies = cinemaRepository.GetMoviesByCinema(id);
            return View("/Views/Home/Index.cshtml", movies );
        }
    }
}
