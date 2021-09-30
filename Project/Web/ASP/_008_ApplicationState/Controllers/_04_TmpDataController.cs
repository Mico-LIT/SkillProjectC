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
     "Место хранения  : Http Cookies или sever-sede code           " +
     "Время жизни     : До первого чтения      " +
     "Контекст        : Все приложение            " +
     "Безопастность   : Безопасны, так как не пересылаются на клиент. Опасность перехвата сессии")]
    public class _04_TmpDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
