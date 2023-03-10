using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UniversityImagesController : Controller
    {
        private IAztobirService _aztobirService;
        private IWebHostEnvironment _env;

        public UniversityImagesController(IAztobirService aztobirService,IWebHostEnvironment env)
        {
            _aztobirService = aztobirService;
            _env = env;
        }
        [Route("/admin/university/images/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                UniversityViewVM universityView = new UniversityViewVM()
                {
                    Photos = await _aztobirService.UniversityService.GetPhotos(id),
                };
                return View(universityView);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Route("/admin/university/images/create/{id}")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("/admin/university/images/create/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,CreateUniPhotosVM photo)
        {
            try
            {
                if (!ModelState.IsValid) return View(photo);
                var model = await _aztobirService.UniversityPhotoService.Create(id, photo, _env.WebRootPath);
                if (model == "ok")
                {
                    return RedirectToAction("Index", "University", new { area = "admin" }); ;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, model);
                    return View(photo);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Route("/admin/university/images/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                return View(await _aztobirService.UniversityPhotoService.GetPhoto(id));
            }
            catch (Exception)
            {
                return Json("Not Found");
            }
        }
        [Route("/admin/university/images/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateUniversityPhotosVM photos)
        {
            var model = await _aztobirService.UniversityPhotoService.Update(id, photos, _env.WebRootPath);
            if (model == "ok")
            {
                return RedirectToAction("Index", "University", new { area = "admin" }); ;
            }
            else
            {
                ModelState.AddModelError(string.Empty, model);
                return View(photos);
            }
        }
        [Route("/admin/university/images/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.UniversityPhotoService.Delete(id);
                return RedirectToAction("Index", "University", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "University", new { area = "admin" });
            }
        }
    }
}
