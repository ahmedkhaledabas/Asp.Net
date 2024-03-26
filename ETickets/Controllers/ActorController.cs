using ETickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class ActorController : Controller
    {

        ETicketsDbContext Context = new ETicketsDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowDetails(int id)
        {
            return View(Context.Actors.Find(id));
        }
    }
}
