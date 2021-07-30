using HogeSchoolPXL.UI.Infrastructure;
using HogeSchoolPXL.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public CookiesController(UserManager<IdentityUser> userManager, 
                                 SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm]LoginModel model)
        {
            var existing = await _userManager.FindByNameAsync(model.Email);
            if (existing is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(existing, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect("/");
                } 
                else
                {
                    Messanger.Message = "Invalid login attempt";
                }
            }
            else
            {
                Messanger.Message = "User does not exists";
                return Redirect("/register");
            }
          
            return Redirect("/login");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
