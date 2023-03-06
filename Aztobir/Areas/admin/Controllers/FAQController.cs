using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class FAQController : Controller
        
    {
        private IAztobirService _aztobirService;

        public FAQController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/faq/index")]
        public async Task<IActionResult> Index()
        {
            HomeVM home = new HomeVM()
            {
                FAQs = await _aztobirService.FAQService.GetAll(),
            };
            return View(home);
        }
        [Route("/admin/faq/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                HomeVM home = new HomeVM()
                {
                    FAQ = await _aztobirService.FAQService.Get(id),
                };
                return View(home);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "FAQ", new { area = "admin" });
            }
        }
        [Route("/admin/faq/delete/{id}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.FAQService.Delete(id);
                return RedirectToAction("Index", "FAQ", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
