using HW_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_14.Controllers
{
    public class MathController : Controller
    {
        // GET: Math
        [HttpGet]
        public ActionResult Arithmetic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Arithmetic(Function function)
        {
            function.CalcRoots();

            ViewBag.Roots = "Root1 = " + function.Root.RealRoot1 + " + i * " + function.Root.ImaginaryRoot1 +
                " Root2 = " + function.Root.RealRoot2 + " + i * " + function.Root.ImaginaryRoot2;

            return View(function);
        }
    }
}