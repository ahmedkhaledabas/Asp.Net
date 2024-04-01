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
            movieRepository.incramenter(id);
            var movie = movieRepository.ReadById(id);
            return View(movie);
        }

        public IActionResult CreateNew()
        {
            ViewData["categories"] = categoryRepository.ReadAll();
            ViewData["cinemas"] = cinemaRepository.ReadAll();
            ViewData["actors"] = movieRepository.GetActors();
            return View(new MovieViewModel());
        }

        public IActionResult SaveNew(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
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
            ViewData["categories"] = categoryRepository.ReadAll();
            ViewData["cinemas"] = cinemaRepository.ReadAll();
            return View("CreateNew", movieViewModel);
            
        }

        public IActionResult Search(string searchItem)
        {
            searchItem = searchItem.Trim();
            return View("Index", movieRepository.Search(searchItem));
        }

        public IActionResult EditMovie(int id)
        {
            var movie = movieRepository.ReadById(id);
            ViewData["categories"] = categoryRepository.ReadAll();
            ViewData["cinemas"] = cinemaRepository.ReadAll();
            var movieViewModel = new MovieViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                CategoryId = movie.CategoryId,
                CinemaId = movie.CinemaId,
                ImgUrl = movie.ImgUrl,
                TrailerUrl = movie.TrailerUrl,
                Price = movie.Price

            };
            return View( movieViewModel);
        }

        public IActionResult SaveChanges(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
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
                movieRepository.Update(movie);
                return RedirectToAction("Index");
            }
            ViewData["categories"] = categoryRepository.ReadAll();
            ViewData["cinemas"] = cinemaRepository.ReadAll();
            return View("EditMovie", movieViewModel);
           
        }

        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
