using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Invigulus.Business;
using Invigulus.Data.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Invigulus.App.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Examinee examinee)
        {
            // authenticate using ExamineeManager
            var ex = ExamineeManager.Authenticate(examinee.ExamineeId, examinee.ExamineeEmail);

            if (examinee == null)
            {
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, ex.ExamineeFirstname),
                new Claim(ClaimTypes.Email, ex.ExamineeEmail)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            if (TempData["ReturnUrl"] == null)
            {
                return Redirect("/");
                //RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }
        }
    }
}
