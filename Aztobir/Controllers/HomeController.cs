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
                News = await _aztobirService.NewsService.GetTake(3),
                Feedbacks = await _aztobirService.FeedbackService.GetAll(),
            };
            ViewBag.Universitet_Head = _aztobirService.SettingSerivice.GetSetting("Universitet-Head");
            ViewBag.Universitet_Content = _aztobirService.SettingSerivice.GetSetting("Universitet-Content");
            ViewBag.Feedback_Content= _aztobirService.SettingSerivice.GetSetting("Feedback-Content");
            ViewBag.Feedback_Head = _aztobirService.SettingSerivice.GetSetting("Feedback-Head");
            ViewBag.Faq_Head = _aztobirService.SettingSerivice.GetSetting("Faq-Head");
            ViewBag.Faq_Content = _aztobirService.SettingSerivice.GetSetting("Faq-Content");
            return View(home);
        }
    }
}