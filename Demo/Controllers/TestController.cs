using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class TestController : Controller
    {
        public ViewResult Ind()
        {
            return View("Index");
        }

        public IActionResult maxx(int x)
        {
            if (x > 5)
            {
                return new ViewResult() { ViewName = "big" };
                }
            else return new ViewResult() { ViewName = "small" };
        } 


    }
}
