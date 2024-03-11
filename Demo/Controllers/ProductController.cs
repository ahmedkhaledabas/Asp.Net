using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            SampleProductsData sample = new SampleProductsData();

            return View(sample.Products);
        }
    }
}
