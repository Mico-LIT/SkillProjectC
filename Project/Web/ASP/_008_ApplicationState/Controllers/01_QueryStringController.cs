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
    public class QueryStringController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
