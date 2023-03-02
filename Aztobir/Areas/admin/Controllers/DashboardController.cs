using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
    [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
