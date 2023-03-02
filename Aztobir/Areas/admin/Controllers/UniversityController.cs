using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UniversityController : Controller
    {
        private IAztobirService _aztobirService;

        public UniversityController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/university/index")]
        public async Task<IActionResult> Index()
        {
            UniversityViewVM universityView = new UniversityViewVM()
            {
                Universities = await _aztobirService.UniversityService.GetAll(),
            };
            return View(universityView);
        }
        [Route("/admin/university/create")]
        public IActionResult Create()
        {
            return Json("create");
        }
    }
}
