using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_14.Controllers
{
    public class RandomizersController : Controller
    {
        private static Random rnd = new Random();
        // GET: Randomizers
        public ActionResult StartPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Randomizer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Randomizer(Models.Randomizer randomizer)
        {
            ViewBag.RandomNumber = randomizer.GenerateNumber(rnd);

            return View(randomizer);
        }

        [HttpGet]
        public ActionResult Lotery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Lotery(Models.Randomizer randomizer)
        {
            ViewBag.Message = "Вы ничего не выиграли";

            for(int i = 0; i < randomizer.MaxNumber / 10; i++)
            {
                if(randomizer.GenerateNumber(rnd) == randomizer.Number)
                {
                    ViewBag.Message = "Вы выиграли";
                }
            }

            return View(randomizer);
        }
    }
}