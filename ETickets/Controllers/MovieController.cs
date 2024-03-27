using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class MovieController : Controller
    {
        ETicketsDbContext Context = new ETicketsDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowDetails(int id)
        {
            

            var movie = Context.Movies.Include(m=>m.Actors)
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
    }
}
