using Inveon.ECommerce.DataAccess.EntityFramework;
using Inveon.ECommerce.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inveon.ECommerce.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ECommerceDBContext _context;

        public AuthController(ECommerceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            if (LoginUser(loginModel.Username, loginModel.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        private bool LoginUser(string username, string password)
        {

            var user = _context.Users.Where(p => p.Username == username && p.Password==password && p.IsAdmin==true).FirstOrDefault();

            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async  Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index");
        }
    }
}
