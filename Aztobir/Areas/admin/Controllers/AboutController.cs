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
        [Route("/admin/about/index")]
        public async Task<IActionResult> Index()
        {
            AboutViewVM about = new AboutViewVM()
            {
                About = await _aztobirService.AboutService.Get(),
                //Goal = await _aztobirService.GoalService.GetAll(),
            };
            return View(about);
        }
    }
}
