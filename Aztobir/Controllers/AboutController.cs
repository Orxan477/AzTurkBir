using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
