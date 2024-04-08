
using ETickets.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole(roleViewModel.Name);
                var res = await roleManager.CreateAsync(role);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(roleViewModel); ;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole identityRolr)
        {
            var role = await roleManager.FindByIdAsync(identityRolr.Id);
            if(role != null)
            {
                role.Name = identityRolr.Name;
                var update = await roleManager.UpdateAsync(role);
                if (update.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit", identityRolr);
                }
            }
            return View("Edit", identityRolr);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role != null)
            {
                var check = await roleManager.DeleteAsync(role);
                if (check.Succeeded)
                {
                return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit", role);
                }
               
            }
            return RedirectToAction("Index");
        }


    }
}
