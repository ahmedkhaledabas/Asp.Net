using ETickets.IRepository;
using ETickets.Models;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ETickets.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ICartRepository cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }


        public IActionResult Index(string id)
        {
            var user = cartRepository.GetUser(id);
            var movies = cartRepository.ReadAll(user);
            return View(movies);
        }


        public IActionResult AddToCart(int movieId , string userId)
        {
            //var userd = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var movie = cartRepository.GetMovie(movieId);
            var user = cartRepository.GetUser(userId);

            if (movie == null || user == null)
            {
                return NotFound();
            }

            // Check if the user already has a cart
            var cart = cartRepository.CheckCart(user);
            if(cart==null)
            {
                //dont have cart
                 cart = new Cart()
                {
                    Movies = new List<Movie>() { movie },
                    ApplicationUser = user,
                    ApplicationUserId = userId
                };
                cartRepository.Create(cart);


            }
            else
            {
                // aleready have cart

                //check if user have this movie

                //if(moveiCart == null)
                //{
                cart.Movies.Add(movie);
                return RedirectToAction("Index", "Movie");
                //}
                //else
                //{
                //    cartRepository.PlusQuntity(cart);
                //}

            }
            return RedirectToAction("Index" , "Movie");
        }

        public IActionResult Delete(int id)
        {
            cartRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //public IActionResult PlusOne(int id)
        //{
        //    var cart = cartRepository.ReadById(id);
        //    cartRepository.PlusQuntity(cart);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult MinusOne(int id)
        //{
        //    var cart = cartRepository.ReadById(id);
        //    cartRepository.MinusQuntity(cart);
        //    return RedirectToAction("Index");
        //}

        public IActionResult Recet()
        {
            cartRepository.Recet();
            return RedirectToAction("Index");
        }

    }
}
