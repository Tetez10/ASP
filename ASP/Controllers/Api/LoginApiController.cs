using ASP.Areas.Identity.Data;
using ASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext context;

        public LoginApiController(SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            this.signInManager = signInManager;
            this.context = context;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login(LoginModel model)
        {
            var signInResult = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}

