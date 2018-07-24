using System.Threading.Tasks;
using bookglobe_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookglobe_backend.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<BookAdmin> userManager;
        private readonly SignInManager<BookAdmin> signInManager;
        public AccountController(
        UserManager<BookAdmin> userManager, SignInManager<BookAdmin> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

        }

        [HttpPost("register")]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] AuthModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new BookAdmin { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(user);
                }
                return StatusCode(500);
            }
            return BadRequest(model);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] AuthModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return Unauthorized();
            }
            return BadRequest(model);
        }

        [Authorize]
        [HttpPost("logout")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}