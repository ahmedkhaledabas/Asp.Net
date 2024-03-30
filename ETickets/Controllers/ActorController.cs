using ETickets.Data;
using ETickets.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class ActorController : Controller
    {

        IActorRepository actorRepository;

        public ActorController(IActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowDetails(int id)
        {
            var actor = actorRepository.ReadById(id);
            return View(actor);
        }
    }
}
