using BikeStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add(int id , int quantity)
        {
            ViewData["quantity"] = quantity;
            return View(context.Products.First(e => e.ProductId == id));
        }
    }
}
