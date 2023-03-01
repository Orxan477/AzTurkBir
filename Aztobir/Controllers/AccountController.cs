using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
