using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class GoalController : Controller
    {
        private IAztobirService _aztobirService;

        public GoalController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/goal/index")]
        public async Task<IActionResult> Index()
        {
            AboutViewVM about = new AboutViewVM()
            {
                Goals = await _aztobirService.GoalService.GetAll(),
            };
            return View(about);
        }
        [Route("/admin/goal/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                AboutViewVM about = new AboutViewVM()
                {
                    Goal = await _aztobirService.GoalService.Get(id),
                };
                return View(about);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
    }
}
