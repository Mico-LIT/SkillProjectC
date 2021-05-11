using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imickey.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult FirstVersionMySite()
        {
            return View();
        }


        public string Error()
        {
            return "Error";
        }
    }
}
