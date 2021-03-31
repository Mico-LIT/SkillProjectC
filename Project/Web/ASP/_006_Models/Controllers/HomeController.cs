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

        public IActionResult _003_SingleModel()
        {
            Models._003_SinglModel.Game game = new Models._003_SinglModel.Game()
            {
                Name = "Pank",
                Platform = "PC",
                Engine = "Unity"
            };

            return View(game);
        }

        public IActionResult _003_Models()
        {
            List<Models._003_SinglModel.Game> game = new List<Models._003_SinglModel.Game>()
            {
                new Models._003_SinglModel.Game(){Name = "1" ,Platform = "PC" , Engine = "11"},
                new Models._003_SinglModel.Game(){Name = "2" ,Platform = "Xbox" , Engine = "22"},
                new Models._003_SinglModel.Game(){Name = "3" ,Platform = "psp" , Engine = "33"},
            };

            return View(game);
        }
    }
}
