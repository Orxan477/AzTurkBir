using Aztobir.Business.Interfaces.About;
using Aztobir.Business.ViewModels.About;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class AboutController : Controller
    {
        private IAboutService _aboutService;
        private IGoalService _goalService;
        public AboutController(IAboutService aboutService, IGoalService goalService)
        {
            _aboutService = aboutService;
            _goalService = goalService;
        }
        public async Task<IActionResult> Index()
        {
            AboutViewVM about = new AboutViewVM()
            {
                About = await _aboutService.Get(),
                Goal = await _goalService.GetAll(),
            };
            return View(about);
        }
    }
}
