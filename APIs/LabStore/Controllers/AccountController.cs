using LabStore.DTOs;
using LabStore.Models;
using LabStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var users = userManager.Users.ToList();
            var userDtos = TransferUser.UsersToUserDtos(users);
            return Ok(userDtos);
        }


        [HttpGet]
        [Route("GetById{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                var userDto = TransferUser.UserToUserDto(user);
                return Ok(userDto);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Registeration(ApplicationUserDTO applicationUserDTO)
        {
            if (ModelState.IsValid)
            {
               var user = TransferUser.UserDtoToUser(applicationUserDTO);
                var created = await userManager.CreateAsync(user, applicationUserDTO.PasswordHash);
                if (created.Succeeded)
                {
                    return Ok(applicationUserDTO);
                }
                foreach (var error in created.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userLoginDTO.UserName);
                if (user != null)
                {
                    var checkPass = await userManager.CheckPasswordAsync(user, userLoginDTO.Password);
                    if (checkPass)
                    {
                        await signInManager.SignInAsync(user, userLoginDTO.RememberMe);
                        return Ok(userLoginDTO);
                    }
                    ModelState.AddModelError(string.Empty, "Invalid UserName Or Password");
                }
                return BadRequest();
            }
            ModelState.AddModelError(string.Empty, "Invalid UserName Or Password");
            return BadRequest();
        }

        
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var isDeletes =await userManager.DeleteAsync(user);
                if (isDeletes.Succeeded)
                {
                    var userDto = TransferUser.UserToUserDto(user);
                    return Ok(userDto);
                }
                
            }
            return NotFound();
        }

    }
}
