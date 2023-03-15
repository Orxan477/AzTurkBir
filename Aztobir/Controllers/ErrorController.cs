using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult CustomNotFound()
        {
            return View();
        }
        public IActionResult CustomBadRequest()
        {
            return View();
        }
    }
}
