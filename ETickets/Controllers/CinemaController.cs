using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.ViewModels;
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
            return View("/Views/Movie/Index.cshtml", movies );
        }

        public IActionResult Create()
        {
            return View(new CinemaViewModel());
        }

        public IActionResult SaveNew(CinemaViewModel cinemaViewModel)
        {
            if (ModelState.IsValid)
            {
            var cinema = new Cinema()
            {
                Id = cinemaViewModel.Id,
                Name = cinemaViewModel.Name,
                Description = cinemaViewModel.Description,
                Address = cinemaViewModel.Address,
                CinemaLogo = cinemaViewModel.CinemaLogo
            };
            cinemaRepository.Create(cinema);
            return RedirectToAction("Index");
            }
            return View("Create", cinemaViewModel);
        }

        public IActionResult Delete(int id)
        {
            cinemaRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditCinema(int id)
        {
            var cinema = cinemaRepository.ReadById(id);
            
                var cinemaViewModel = new CinemaViewModel()
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    Address = cinema.Address,
                    Description = cinema.Description,
                    CinemaLogo = cinema.CinemaLogo
                };
                return View(cinemaViewModel);
        }

        public IActionResult SaveChanges(CinemaViewModel cinemaViewModel)
        {
            if (ModelState.IsValid)
            {
            var cinema = new Cinema()
            {
                Id = cinemaViewModel.Id,
                Name = cinemaViewModel.Name,
                Description = cinemaViewModel.Description,
                Address = cinemaViewModel.Address,
                CinemaLogo = cinemaViewModel.CinemaLogo
            };
            cinemaRepository.Update(cinema);
            return RedirectToAction("Index");
            }
            return View("EditCinema", cinemaViewModel);
        }
    }
}
