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
        "Место хранения  : Http Cookies           " +
        "Время жизни     : Определяеться разработчиком      " +
        "Контекст        : Все приложение            " +
        "Безопастность   : доступна для просмотра. Легко меняеться ")]
    public class _02_CookiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
