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

                return RedirectToAction("Index", "Goal", new { area = "admin" });
            }
        }
        [Route("/admin/goal/create/")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/admin/goal/create/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GoalCreateVM goal)
        {
            if (!ModelState.IsValid) return View(goal);
           await _aztobirService.GoalService.Create(goal);
            return RedirectToAction("Index");
        }

        [Route("/admin/goal/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var goal = await _aztobirService.GoalService.Get(id);
            if (goal is null) return NotFound();
            return View(goal);
        }
        [Route("/admin/goal/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,GoalVM goal)
        {
            try
            {
                if (!ModelState.IsValid) return View(goal);
                await _aztobirService.GoalService.Update(id, goal);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Route("/admin/goal/delete/{id}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.GoalService.Delete(id);
                return RedirectToAction("Index", "Goal", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Goal", new { area = "admin" });
            }

        }
    }
}
