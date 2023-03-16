using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home;
using Aztobir.Business.ViewModels.Home.Feedback;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class FeedbackController : Controller
    {
        private IAztobirService _aztobirService;
        private IWebHostEnvironment _env;

        public FeedbackController(IAztobirService aztobirService, IWebHostEnvironment env)
        {
            _aztobirService = aztobirService;
            _env = env;
        }
        [Route("/admin/feedback/index")]
        public async Task<IActionResult> Index(int page=1)
        {
            int takeCount = int.Parse("3");
            //int count = int.Parse(GetSetting("TakeCount"));
            ViewBag.TakeCount = takeCount;
            var model = await _aztobirService.FeedbackService.GetPaginete(page, takeCount);
            return View(model);
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
        [Route("/admin/feedback/create/")]
        public async Task<IActionResult> Create()
        {
            await GetSelectedItemAsync();
            return View();
        }
        [Route("/admin/feedback/create/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFeedbackVM feedback)
        {
            if (!ModelState.IsValid) 
            { 
                await GetSelectedItemAsync(); 
                return View(feedback); 
            }
            var saveNews = await _aztobirService.FeedbackService.Create(feedback, _env.WebRootPath,PhotoSize());
            if (saveNews == "ok") return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(string.Empty, saveNews);
                await GetSelectedItemAsync();
                return View(feedback);
            }
        }
        [Route("/admin/feedback/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                await GetSelectedItemAsync();
                var model = await _aztobirService.FeedbackService.GetUpdate(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("admin/feedback/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateFeedbackVM feedback)
        {
            try
            {
                var model = await _aztobirService.FeedbackService.Update(id, feedback, _env.WebRootPath, PhotoSize());
                if (model != "ok")
                {
                    ModelState.AddModelError(string.Empty, model);
                    await GetSelectedItemAsync();
                    return View(feedback);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("/admin/feedback/delete/{id}")]
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
        private async Task GetSelectedItemAsync()
        {
            ViewBag.university = new SelectList(await _aztobirService.UniversityService.GetAll(), "Id", "Name");
        }
        private int PhotoSize()
        {
            string photosize = _aztobirService.SettingSerivice.GetSetting("PhotoSize");
            return Convert.ToInt32(photosize);
        }
    }
}
