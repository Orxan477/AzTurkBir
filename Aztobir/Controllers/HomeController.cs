using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aztobir.Controllers
{
    public class HomeController : Controller
    {
        private IAztobirService _aztobirService;
        public HomeController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM home = new HomeVM()
            {
                Universities = await _aztobirService.UniversityService.GetAll(),
                FAQs = await _aztobirService.FAQService.GetAll(),
                News = await _aztobirService.NewsService.GetAll(),
                Feedbacks = await _aztobirService.FeedbackService.GetAll(),
            };
            return View(home);
        }
    }
}