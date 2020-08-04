using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Invigulus.App.Controllers
{
    public class ExamPageController : Controller
    {
        public IActionResult Loading()
        {
            return View();
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
