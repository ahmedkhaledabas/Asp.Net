using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class CategoryController : Controller
    {
        ETicketsDbContext Context = new ETicketsDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMovies(int id)
        {
            return View("/Views/Home/Index.cshtml",Context.Movies.Where(m => m.CategoryId == id).Include(e => e.Category).Include(e => e.Cinema).ToList());
        }
    }
}
