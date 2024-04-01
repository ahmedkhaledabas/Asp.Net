using ETickets.IRepository;
using ETickets.Models;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class CartController : Controller
    {
        ICartRepository cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public IActionResult Index()
        {
            var carts = cartRepository.ReadAll();
            return View(carts);
        }


        public IActionResult AddToCart(int id)
        {
            var cartViewModel = new CartViewModel()
            {
                MovieId = id
            };
            var cart = new Cart()
            {
                Id = cartViewModel.Id,
                MovieId = cartViewModel.MovieId,
                Quantity = cartViewModel.Quantity,
            };
            cartRepository.Create(cart);
            return RedirectToAction("Index" , "Movie");
        }

        public IActionResult Delete(int id)
        {
            cartRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult PlusOne(int id)
        {
            var cart = cartRepository.ReadById(id);
            cartRepository.PlusQuntity(cart);
            return RedirectToAction("Index");
        }

        public IActionResult MinusOne(int id)
        {
            var cart = cartRepository.ReadById(id);
            cartRepository.MinusQuntity(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Recet()
        {
            cartRepository.Recet();
            return RedirectToAction("Index");
        }

    }
}
