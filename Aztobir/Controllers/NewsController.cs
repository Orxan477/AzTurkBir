using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
