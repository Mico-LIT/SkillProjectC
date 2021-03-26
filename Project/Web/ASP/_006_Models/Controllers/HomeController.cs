using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _006_Models.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var methodsList = typeof(HomeController).GetMethods()
                .Where(x => (x.ReturnType == typeof(IActionResult) || x.ReturnType == typeof(string)) && x.IsPublic)
                .Where(x => !x.Name.Equals("ToString") && !x.Name.Equals("Index"))
                .Select(x => x.Name)
                .ToList();

            return View(methodsList);
        }

        public string _001_PlainModel()
        {
            Models._001_PlainModel.Company company = new Models._001_PlainModel.Company()
            {
                Id = 7865723324,
                Name = "Microsoft",
            };

            return $"Id {company.Id} Name {company.Name}";
        }
        public string _002_FatModel()
        {
            Models._002_FatModel.Company company = new Models._002_FatModel.Company(12312312, "Microsoft");

            return company.GetInfo();
        }
    }
}
