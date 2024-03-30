using ETickets.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View( new UserViewModel());
        }

        public IActionResult LogIn()
        {
            return View(new UserViewModel());
        }


        [AutoValidateAntiforgeryToken]
        public IActionResult SaveUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SignUp");
            }
            return View("SignUp", userViewModel);
        }
    }
}
