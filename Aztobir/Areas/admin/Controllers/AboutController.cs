using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private IAztobirService _aztobirService;

        public AboutController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/about/index/")]
        public async Task<IActionResult> Index()
        {
            AboutViewVM about = new AboutViewVM()
            {
                About = await _aztobirService.AboutService.Get(),
            };
            return View(about);
        }
        [Route("/admin/about/detail/")]
        public async Task<IActionResult> Detail()
        {
            AboutViewVM about = new AboutViewVM()
            {
                About = await _aztobirService.AboutService.Get(),
            };
            return View(about);
        }
    }
}
