using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using ETickets.Services;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        List<CartViewModel> cartItems;


        public CartController(ICartRepository cartRepository ) {
            this.cartRepository = cartRepository;
        }


        public IActionResult Index()
        {
            // Retrieve data from session and pass it to the view
            
            if (HttpContext.Session.TryGetValue("CartItems", out byte[] sessionCartItemsBytes))
            {
                cartItems = System.Text.Json.JsonSerializer.Deserialize<List<CartViewModel>>(sessionCartItemsBytes);
            }
            else
            {
                cartItems = new List<CartViewModel>();
            }
            return View(cartItems);
        }

        public IActionResult AddToCart(CartViewModel cart)
        {
            if (ModelState.IsValid)
            {
                // Retrieve existing cart items from session or create a new list if none exists
                if (HttpContext.Session.TryGetValue("CartItems", out byte[] sessionCartItemsBytes))
                {
                    cartItems = System.Text.Json.JsonSerializer.Deserialize<List<CartViewModel>>(sessionCartItemsBytes);
                }
                else
                {
                    cartItems = new List<CartViewModel>();
                }

                // Add new cart item to the list
                cartItems.Add(new CartViewModel
                {
                    MovieName = cart.MovieName,
                    Date = cart.Date,
                    Quantity = cart.Quantity
                });

                // Save the updated cart items list to the session
                byte[] cartItemsBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(cartItems);
                HttpContext.Session.Set("CartItems", cartItemsBytes);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Book(int id)
        {
            var movie = cartRepository.GetMovie(id);
            
            return View(movie);
        }


        public IActionResult Recet()
        {
           HttpContext.Session.Remove("CartItems");
            return RedirectToAction("Index");
        }


        public IActionResult BuyNow(string id)
        {
            if (HttpContext.Session.TryGetValue("CartItems", out byte[] sessionCartItemsBytes))
            {
                cartItems = System.Text.Json.JsonSerializer.Deserialize<List<CartViewModel>>(sessionCartItemsBytes);
                var user = cartRepository.GetUser(id);
                SendEmail.Send(user,cartItems);
                TempData["buySuccess"] = "Congratulation, Tickets Are Booked";
                return RedirectToAction("Recet");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}
