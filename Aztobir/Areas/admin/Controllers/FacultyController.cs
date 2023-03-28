using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class FacultyController : Controller
    {
        [Route("/admin/faculty/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
