using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace _008_ApplicationState.Controllers
{
    [Description(
     "Допустивые типы : 'Любые типы данных'   " +
     "Место хранения  : sever-sede code           " +
     "Время жизни     : Определяеться разработчиком      " +
     "Контекст        : Все приложение            " +
     "Безопастность   : Не передаются на клиент")]
    public class CacheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
