using Microsoft.AspNetCore.Mvc;

namespace _008_ApplicationState.Controllers
{
    public class _07_SimpleProblemsController : Controller
    {
        // На запрос к каждому методу действия создаеться новый экземпляо контроллера
        // Поле State содержит состояние во время обработки запроса.
        // При след обращении значение будет равно по умолчанию
        private string state;

        // Поле живет и к нему могут обращаться несколько клиентов
        //private static string state;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            state = value;
            return View();
        }

        public IActionResult Test()
        {
            return View(state as object);
        }
    }
}
