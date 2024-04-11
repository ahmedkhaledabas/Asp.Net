using ETickets.Models;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ETickets.Controllers
{
    
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
          
            return View(userManager.Users.ToList());
        }

        [HttpGet]
        public IActionResult Registeration()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Movie");
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registeration(ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    FirstName = applicationUserViewModel.FirstName,
                    LastName = applicationUserViewModel.LastName != null ? applicationUserViewModel.LastName : "" ,
                    Gender = applicationUserViewModel.Gender,
                    PhoneNumber = applicationUserViewModel.PhoneNumber,
                    PasswordHash = applicationUserViewModel.PasswordHash,
                    UserName = applicationUserViewModel.UserName,
                    Address = applicationUserViewModel.Address != null ? applicationUserViewModel.Address : "",
                    Email = applicationUserViewModel.Email,
                    Image = applicationUserViewModel.Image,


                };
                IdentityResult identityResult = await userManager.CreateAsync(applicationUser, applicationUserViewModel.PasswordHash);
                if (identityResult.Succeeded)
                {
                    var res = await userManager.AddToRoleAsync(applicationUser, "User");
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(applicationUserViewModel);
                }
                
            }
            else
            {
                return View(applicationUserViewModel);
            }
           
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Movie");
            }
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = await  userManager.FindByNameAsync(userLoginViewModel.UserName);
                if(user != null)
                {
                    var checkPass = await userManager.CheckPasswordAsync(user, userLoginViewModel.Password);
                    if (checkPass)
                    {
                        //session
                        await signInManager.SignInAsync(user, userLoginViewModel.RememberMe);
                        HttpContext.Session.SetString("userId", user.Id);
                        //await signInManager.SignInWithClaimsAsync(user, userLoginViewModel.RememberMe, new List<Claim>
                        //{
                        //    new Claim(ClaimTypes.GivenName, user.FirstName),
                        //    new Claim(ClaimTypes.Gender, user.Gender.ToString()),
                        //    new Claim("Image", (user.Image == null ? "default.jpg" : user.Image)),
                        //    new Claim(ClaimTypes.NameIdentifier , user.Id)
                        //});
                        return RedirectToAction("Index", "Movie");
                    }
                    else ModelState.AddModelError(string.Empty, "Invalid UserName Or Password");

                }
                else ModelState.AddModelError(string.Empty, "Invalid UserName Or Password");
            }
        return View(userLoginViewModel);
               
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Movie");
        }



        public async Task<IActionResult> Delete(string id)
        {
           var user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                var isDeleted = await userManager.DeleteAsync(user);
                if (isDeleted.Succeeded)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    string role = "";
                    foreach (var rol in roles)
                    {
                        role = rol;
                    }
                    if (role == "Admin")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Logout");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(ApplicationUser applicationUser)
        {
            var user = await userManager.FindByIdAsync(applicationUser.Id);
            if(user != null)
            {
                if (ModelState.IsValid)
                {
                user.FirstName = applicationUser.FirstName;
                user.LastName = applicationUser.LastName == null ? "" : applicationUser.LastName ;
                user.Address = applicationUser.Address == null ? "" : applicationUser.Address;
                user.PhoneNumber = applicationUser.PhoneNumber;
                user.Email = applicationUser.Email;
                user.UserName = applicationUser.UserName;
                    user.Image = applicationUser.Image == null ? user.Image : applicationUser.Image;

                   var update = await userManager.UpdateAsync(user);
                    if (update.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);
                        string role = "";
                        foreach (var rol in roles)
                        {
                            role = rol;
                        }
                        if (role == "Admin")
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Movie");
                        }
                    }
                    else
                    {
                        return View("Edit", user);
                    }

                }
                else
                {
                    return View("Edit", applicationUser);
                }
               
            }
            return View(applicationUser);
        }


    }
}