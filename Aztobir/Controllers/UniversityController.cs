using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class UniversityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
