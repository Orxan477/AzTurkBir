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
            ViewBag.About_Head = _aztobirService.SettingSerivice.GetSetting("About-Head");
            ViewBag.About_Content = _aztobirService.SettingSerivice.GetSetting("About-Content");
            return View(about);
        }
    }
}
