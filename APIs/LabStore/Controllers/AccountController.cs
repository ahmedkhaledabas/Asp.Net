using LabStore.DTOs;
using LabStore.Models;
using LabStore.Services;
using Microsoft.AspNetCore.Authorization;
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

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await userManager.Users.ToListAsync();
            return Ok(TransferUser.UsersToUserDtos(users));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(string id)
        {
            var isAdmin = User.IsInRole("Admin");
            var currentUserId = userManager.GetUserId(User);
            if (!isAdmin && currentUserId != id)
            {
                return Forbid();
            }

            var user = await userManager.FindByIdAsync(id);
            return user is null ? NotFound() : Ok(TransferUser.UserToUserDto(user));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Registeration([FromBody] ApplicationUserDTO dto)
        {
            var user = TransferUser.UserDtoToUser(dto);
            var created = await userManager.CreateAsync(user, dto.Password);

            if (!created.Succeeded)
            {
                foreach (var error in created.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem(ModelState);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = user.Id },
                TransferUser.UserToUserDto(user));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
            var result = await signInManager.PasswordSignInAsync(
                dto.UserName,
                dto.Password,
                dto.RememberMe,
                lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            var user = await userManager.FindByNameAsync(dto.UserName);
            return user is null
                ? Unauthorized(new { message = "Invalid username or password." })
                : Ok(TransferUser.UserToUserDto(user));
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    errors = result.Errors.Select(error => error.Description)
                });
            }

            return NoContent();
        }
    }
}
