using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Invigulus.Business;
using Invigulus.Data.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
//using System.Security.Claims.ClaimsPrincipal;
using System.Security.Principal;
using System.Threading;

namespace Invigulus.App.Controllers
{
    public class ExamineeController : Controller
    {
        // generate view to add new examinee
        public IActionResult Create()
        {
            return View();
        }

        // add new asset to database
        [HttpPost]
        public IActionResult Create(Examinee examinee)
        {
            // if new asset type is successfully added to db, redirect to login page. if not, reload current view
            try
            {
                ExamineeManager.Add(examinee);
                Console.WriteLine("success" + examinee);
                return RedirectToAction("Index", "UserAuth");
            }
            catch
            {
                Console.WriteLine("fail" + examinee);
                return View();
            }
        }

        public IActionResult Thanks()
        {
            //var userId = HttpContext.Request.Cookies.Keys;      /*   context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;*/
            //httpcookie
            //var userName = HttpContext.Request.Cookies.ContainsKey("Name");

            //var principal = System.Security.Claims.ClaimsPrincipal.Current;
            //string fname = principal.FindFirst(ClaimTypes.Name).Value;

            //ViewBag.userName = fname;


            ////Get the current claims principal
            //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            //// Get the claims values
            //var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
            //                   .Select(c => c.Value).SingleOrDefault();
            ////var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
            ////                   .Select(c => c.Value).SingleOrDefault();
            ///
            //var claimsIdentity = (ClaimsIdentity)this.RequestContext.Principal.Identity;
            //var name = null;
            //foreach (var claim in claimsIdentity.Claims)
            //{
            //    name = claim.Value;
            //    // claim.value;
            //    // claim.Type
            //}

        

            //ViewBag.userName = name;



            return View();
        }
    }
}
