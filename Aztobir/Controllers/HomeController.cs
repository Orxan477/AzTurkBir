using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aztobir.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}