using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace imickey.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1()
        {
            var dateStart = new DateTime(2016, 11, 1);
            double digital = Math.Floor(DateTime.UtcNow.Subtract(dateStart).TotalDays / 365);
            ViewBag.DateWork = digital;

            return View();
        }

        public string Error()
        {
            return "Error";
        }
    }
}