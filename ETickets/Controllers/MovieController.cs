using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository movieRepository;
        ICategoryRepository categoryRepository;
        ICinemaRepository cinemaRepository;

        public MovieController(IMovieRepository movieRepository , ICinemaRepository cinemaRepository , ICategoryRepository categoryRepository)
        {
            this.movieRepository = movieRepository;
            this.categoryRepository = categoryRepository;
            this.cinemaRepository = cinemaRepository;
        }
        public IActionResult Index()
        {
            return View(movieRepository.ReadAll());
        }

        public IActionResult ShowDetails(int id)
        {
            var movie = movieRepository.ReadById(id);
            return View(movie);
        }

        public IActionResult CreateNew()
        {
            ViewData["categories"] = categoryRepository.ReadAll();
            ViewData["cinemas"] = cinemaRepository.ReadAll();
            return View(new MovieViewModel());
        }

        public IActionResult SaveNew(MovieViewModel movieViewModel)
        {
            var movie = new Movie()
            {
                Id = movieViewModel.Id,
                Name = movieViewModel.Name,
                Description = movieViewModel.Description,
                StartDate = movieViewModel.StartDate,
                EndDate = movieViewModel.EndDate,
                CategoryId = movieViewModel.CategoryId,
                CinemaId = movieViewModel.CinemaId,
                ImgUrl = movieViewModel.ImgUrl,
                TrailerUrl = movieViewModel.TrailerUrl,
                Price = movieViewModel.Price
            };
            movieRepository.Create(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchItem)
        {
            return View("Index", movieRepository.Search(searchItem));
        }
    }
}
