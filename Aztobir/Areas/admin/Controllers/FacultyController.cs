using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.Faculty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class FacultyController : Controller
    {
        private IAztobirService _aztobirService;

        public FacultyController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/faculty/index")]
        public async Task<IActionResult> Index()
        {
            return View(await _aztobirService.FacultyService.GetAll());
        }
        [Route("/admin/faculty/create/")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("/admin/faculty/create/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacultyCreateVM faculty)
        {
            var model = await _aztobirService.FacultyService.Create(faculty);
            if (model != "ok")
            {
                ModelState.AddModelError(string.Empty, model);
                return View(faculty);
            }
            else
            {
                return RedirectToAction("Index","Faculty");
            }
        }
        [Route("/admin/faculty/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var city = await _aztobirService.FacultyService.GetUpdate(id);
                return View(city);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("/admin/faculty/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, FacultyUpdateVM faculty)
        {
            //if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(city);
            var model = await _aztobirService.FacultyService.Update(id, faculty);
            try
            {
                if (model != "ok")
                {
                    ModelState.AddModelError(string.Empty, model);
                    return View(faculty);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("/admin/faculty/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.FacultyService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
    }
}
