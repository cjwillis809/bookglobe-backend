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
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
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
    }
}