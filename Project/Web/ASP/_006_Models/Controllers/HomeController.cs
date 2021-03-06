﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Models.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var methodsList = typeof(HomeController).GetMethods()
                .Where(x => (x.ReturnType == typeof(IActionResult) || x.ReturnType == typeof(string)) && x.IsPublic)
                .Where(x => x.GetParameters().Length <= 0)
                .Where(x => !x.Name.Equals("ToString") && !x.Name.Equals("Index"))
                .Select(x => (x.Name, $"Home/{x.Name}"))
                .ToList();

            var filesControllerMethodsList = typeof(FilesController).GetMethods()
                .Where(x => (x.ReturnType.BaseType == typeof(FileResult) ||
                             x.ReturnType == typeof(IActionResult) ||
                             x.ReturnType == typeof(FileResult)) && x.IsPublic)
                .Where(x => x.GetParameters().Length <= 0)
                .Where(x => !x.Name.Equals("ToString") && !x.Name.Equals("Index"))
                .Select(x => (x.Name, $"Files/{x.Name}"))
                .ToList();

            filesControllerMethodsList.ForEach(x =>
            {
                methodsList.Add((x.Name, x.Item2));
            });

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

        public IActionResult _004_ViewModel()
        {
            var pcGames = new List<Models._004_ViewModel.PcGame>()
            {
                new Models._004_ViewModel.PcGame(){ Name = "Batman: Arkham City" , Lang = "C#"},
                new Models._004_ViewModel.PcGame(){ Name = "Hitman 3" , Lang = "C++"},
                new Models._004_ViewModel.PcGame(){ Name = "Ghostrunner" , Lang = "C++"},
            };

            var xboxGames = new List<Models._004_ViewModel.XboxGame>()
            {
                new Models._004_ViewModel.XboxGame(){ Name = "Grand Theft Auto V" , Lang = "C++"},
                new Models._004_ViewModel.XboxGame(){ Name = "Celeste" , Lang = "C++"},
                new Models._004_ViewModel.XboxGame(){ Name = "Resident Evil 2" , Lang = "C++"},
            };

            var resultViewModel = new ViewModels.GamesViewModel();
            resultViewModel.pcGames = pcGames;
            resultViewModel.xboxGames = xboxGames;

            return View(resultViewModel);
        }

        public IActionResult _005_FormForRegisterView()
        {
            return View();
        }

        public string _005_FormForRegister(string name, string surname, int age)
        {
            var user = new Models._005_FormForRegister.User()
            {
                Name = name,
                Surname = surname,
                Age = age
            };

            return $"{user.Name}|{user.Surname}|{user.Age}";
        }

        public IActionResult _005_FormForRegisterListView()
        {
            return View();
        }

        public string _005_FormForRegisterList(Models._005_FormForRegister.User[] users)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var user in users)
            {
                stringBuilder.Append($"{user.Name}|{user.Surname}|{user.Age} {Environment.NewLine}");
            }

            return stringBuilder.ToString();
        }

        public IActionResult _006_ViewImport()
        {
            return View();
        }

        public IActionResult _007_ViewDataBag()
        {
            ViewData["test"] = "ViewData['test']";
            ViewBag.DataBag = "ViewBag.DataBag";
            ViewBag.DataBagTest1 = "ViewBag.DataBagTest1";
            return View();
        }

        public IActionResult _008_MasterPage()
        {
            return View();
        }

        public string _009_RequestHeader()
        {
            string result = "";
            var headers = Request.Headers;

            foreach (var item in headers)
                result += $"{item.Key} = {item.Value} \n";

            return result;
        }
    }
}
