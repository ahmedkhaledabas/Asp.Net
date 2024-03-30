using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class TicketController : Controller
    {
        IMovieRepository movieRepository;
        ITicketRepository ticketRepository;

        public TicketController(IMovieRepository movieRepository, ITicketRepository ticketRepository)
        {
            this.movieRepository = movieRepository;
            this.ticketRepository = ticketRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Book(int id)
        {
            ViewData["movie"] = movieRepository.ReadById(id);
            return View(new TicketViewModel());
        }

        public IActionResult Buy(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                var ticket = new Ticket()
                {
                    id = ticketViewModel.id,
                    DateTime = ticketViewModel.DateTime,
                    Quantity = ticketViewModel.Quantity,
                    MovieId = ticketViewModel.MovieId,

                };
                ticketRepository.Create(ticket);
                return View("Buy", ticketRepository.ReadAll());
            }
            else return View("Book", ticketViewModel);

        }

    }
}

