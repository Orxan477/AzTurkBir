using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.About;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class AboutController : Controller
    {
        private IAztobirService _aztobirService;
        public AboutController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public async Task<IActionResult> Index()
        {
            AboutViewVM about = new AboutViewVM()
            {
                About = await _aztobirService.AboutService.Get(),
                Goals = await _aztobirService.GoalService.GetAll(),
            };
            return View(about);
        }
    }
}
