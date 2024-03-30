using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowDetails(int id)
        {
            var movie = movieRepository.ReadById(id);
            return View(movie);
        }
    }
}
