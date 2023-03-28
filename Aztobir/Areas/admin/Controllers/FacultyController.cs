using Aztobir.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class FacultyController : Controller
    {
        private IAztobirService _aztobirService;

        public FacultyController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/faculty/index")]
        public IActionResult Index()
        {
            return View(_aztobirService.FacultyService.GetAll());
        }
    }
}
