using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace _008_ApplicationState.Controllers
{
    [Description(
        "Допустивые типы : 'String', 'Int32'   " +
        "Место хранения  : Http Cookies + sever-sede code           " +
        "Время жизни     : 20 мин по умолчанию      " +
        "Контекст        : Все приложение            " +
        "Безопастность   : Безопасны, так как не пересылаются на клиент. Опасность перехвата сессии")]
    public class _03_SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
