using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.Position;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class PositionController : Controller
    {
        private IAztobirService _aztobirService;

        public PositionController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/position/index/")]
        public async Task<IActionResult> Index()
        {
            UniversityViewVM uni = new UniversityViewVM()
            {
                Positions =await _aztobirService.PositionService.GetAll(),
            };

            return View(uni);
        }
        [Route("/admin/position/create/")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("/admin/position/create/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePositionVM position)
        {
            if (!ModelState.IsValid) return View(position);
            var savePosition = await _aztobirService.PositionService.Create(position);
            if (savePosition == "ok")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, savePosition);
                return View(position);
            }
        }
        [Route("/admin/position/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var model = await _aztobirService.PositionService.Get(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }

        }
        [Route("/admin/position/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdatePositionVM position)
        {
            try
            {
                var model = await _aztobirService.PositionService.Update(id, position);
                if (model != "ok")
                {
                    ModelState.AddModelError(string.Empty, model);
                    return View(position);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("/admin/position/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.PositionService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }

        }
    }
}
