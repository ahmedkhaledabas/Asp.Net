using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class TicketController : Controller
    {
        ETicketsDbContext context = new ETicketsDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Book(int id)
        {

            //return View(context.Movies.Include.Find(id));
            var movie = context.Movies.Include(m => m.Actors)
               .Include(m => m.Category)
               .Include(m => m.Cinema)
               .FirstOrDefault(m => m.Id == id);
            return View(movie);
        }


        public IActionResult Buy(Movie movie, int quantity , DateTime selectDate)
        {
            ViewData["quantity"] = quantity;
            ViewData["selectDate"] = selectDate;
            return View(movie);
        }
    }
    }

