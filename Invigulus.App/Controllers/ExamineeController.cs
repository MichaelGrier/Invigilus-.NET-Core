using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invigulus.Business;
using Invigulus.Data.Domain;
using Microsoft.AspNetCore.Authorization;
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

        // add new examinee to database
        [HttpPost]
        public IActionResult Create(Examinee examinee)
        {
            // if new examinee is successfully added to db, redirect to login page. if not, reload current view
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

        [Authorize]
        public IActionResult Display()
        {
            var examinee = ExamineeManager.GetLast();
            return View(examinee);
        }

        [Authorize]
        // generate view to edit examinee info
        public ActionResult Edit(int id)
        {
            var examinee = ExamineeManager.Find(id);
            return View(examinee);
        }

        // edit examinee info
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Examinee examinee)
        {
            try
            {
                // call the ExamineeManager to edit
                ExamineeManager.Update(examinee);

                return RedirectToAction("Display");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}