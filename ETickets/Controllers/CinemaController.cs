using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        ETicketsDbContext Context = new ETicketsDbContext();
        public IActionResult Index()
        {
            return View(Context.Cinemas.ToList());
        }

        public IActionResult ShowMovies(int id)
        {
            return View("/Views/Home/Index.cshtml", Context.Movies.Where(m => m.CinemaId == id).Include(e => e.Category).Include(e => e.Cinema).ToList());
        }
    }
}
