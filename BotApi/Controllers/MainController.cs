using Microsoft.AspNetCore.Mvc;

namespace BotApi.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
