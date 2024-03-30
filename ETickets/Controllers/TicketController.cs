using ETickets.Data;
using ETickets.Models;
using ETickets.ViewModels;
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
            ViewData["movie"] = context.Movies.Include(m => m.Actors)
               .Include(m => m.Category)
               .Include(m => m.Cinema)
               .FirstOrDefault(m => m.Id == id);
            return View(new TicketViewModel());
        }

        public IActionResult Buy(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(new()
                {
                    MovieId = ticketViewModel.MovieId,
                    DateTime = ticketViewModel.DateTime,
                    Quantity = ticketViewModel.Quantity
                });
                context.SaveChanges();
                return View("Buy", context.Tickets.Include(t => t.Movie).ThenInclude(m => m.Cinema).ToList());
                //return RedirectToAction("Index" , "Home");
            }
            else return View("Book", ticketViewModel);

        }

    }
}

