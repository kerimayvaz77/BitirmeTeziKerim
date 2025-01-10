using BitirmeTeziKerim.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BitirmeTeziKerim.Controllers
{
    public class LoginController : Controller
    {
        private readonly BitirmeTeziDbContext _context;

        public LoginController(BitirmeTeziDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GirisYap()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AdminTabloes");
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> GirisYap(AdminTablo p)
        {
            var bilgiler = _context.AdminTablos.FirstOrDefault(x => x.Email == p.Email && x.Sifre == p.Sifre);
          
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, p.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(useridentity),
                    authProperties
                );

                return RedirectToAction("Index", "AdminTabloes");
            }
            
            ModelState.AddModelError("", "Email veya şifre hatalı!");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
