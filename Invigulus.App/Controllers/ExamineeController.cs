using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invigulus.Business;
using Invigulus.Data.Domain;
using Microsoft.AspNetCore.Mvc;

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
                return RedirectToAction("Login", "Account");
            }
            catch
            {
                Console.WriteLine("fail" + examinee);
                return View();
            }
        }
    }
}
