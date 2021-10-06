using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _008_ApplicationState.Controllers
{
    [Description(
        "Допустивые типы : 'String'    " +
        "Место хранения  : Http query string           " +
        "Время жизни     : До ввода нового адреса      " +
        "Контекст        : Целевая страница            " +
        "Безопастность   : доступна для просмотра. Легко меняеться ")]
    public class _01_QueryStringController : Controller
    {
        Dictionary<int, string> data;

        public _01_QueryStringController()
        {
            data = new Dictionary<int, string>() {
                {1,"First" },
                {2,"Second" },
                {3,"Third" },
            };
        }

        public IActionResult Index()
        {
            return View(data);
        }

        public IActionResult Details(int id)
        {
            return View((object)data[id]);
        }
    }
}
