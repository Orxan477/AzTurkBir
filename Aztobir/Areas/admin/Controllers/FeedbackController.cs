using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class FeedbackController : Controller
    {
        private IAztobirService _aztobirService;

        public FeedbackController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/feedback/index")]
        public async Task<IActionResult> Index()
        {
            HomeVM home = new HomeVM()
            {
                Feedbacks = await _aztobirService.FeedbackService.GetAll(),
            };
            return View(home);
        }
        [Route("/admin/feedback/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                HomeVM home = new HomeVM()
                {
                    Feedback = await _aztobirService.FeedbackService.Get(id),
                };
                return View(home);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Feedback", new { area = "admin" });
            }
        }
        [Route("/admin/feedback/delete/{id}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.FeedbackService.Delete(id);
                return RedirectToAction("Index", "Feedback", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Feedback", new { area = "admin" });
            }

        }
    }
}
