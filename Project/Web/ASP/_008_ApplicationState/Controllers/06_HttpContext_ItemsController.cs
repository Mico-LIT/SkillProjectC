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
     "Время жизни     : Время обработки запроса      " +
     "Контекст        : Все приложение            " +
     "Безопастность   : Не передаются на клиент")]
    public class HttpContext_ItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
