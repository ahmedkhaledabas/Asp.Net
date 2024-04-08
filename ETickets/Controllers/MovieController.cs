using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MovieController : Controller
    {
        
        IMovieRepository movieRepository;
        
        public MovieController(IMovieRepository movieRepository)
        {
            
            this.movieRepository = movieRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(movieRepository.ReadAll());
        }

        [Authorize(Roles ="Admin")]
        public IActionResult IndexAdmin()
        {
            return View(movieRepository.ReadAll());
        }


        [AllowAnonymous]
        public IActionResult ShowDetails(int id)
        {
            movieRepository.incramenter(id);
            var movie = movieRepository.ReadById(id);
            return View(movie);
        }

        public IActionResult CreateNew()
        {
            ViewData["categories"] = movieRepository.GetCategories();
            ViewData["cinemas"] = movieRepository.GetCinemas();
            ViewData["actors"] = movieRepository.GetActors();
            return View(new MovieViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
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
                foreach (var actor in movieRepository.GetActors())
                {
                    if (Request.Form.ContainsKey(actor.FirstName))
                    {
                        movieRepository.AddActorToMovie(movie.Id, actor.Id);
                    }
                };

                
                return RedirectToAction("Index");
            }
            ViewData["categories"] = movieRepository.GetCategories();
            ViewData["cinemas"] = movieRepository.GetCinemas();
            return View("CreateNew", movieViewModel);
            
        }
        [AllowAnonymous]
        public IActionResult Search(string searchItem)
        {
            searchItem = searchItem.Trim();
            return View("Index", movieRepository.Search(searchItem));
        }

        public IActionResult EditMovie(int id)
        {
            var movie = movieRepository.ReadById(id);
            ViewData["categories"] = movieRepository.GetCategories();
            ViewData["cinemas"] = movieRepository.GetCinemas();
            ViewData["actors"] = movieRepository.GetActors();
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
            ViewData["categories"] = movieRepository.GetCategories();
            ViewData["cinemas"] = movieRepository.GetCinemas();
            return View("EditMovie", movieViewModel);
           
        }

        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
