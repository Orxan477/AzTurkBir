using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.City;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private IAztobirService _aztobirService;
        public CityController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/city/index/")]
        public async Task<IActionResult> Index()
        {
            UniversityViewVM cities = new UniversityViewVM()
            {
                Cities = await _aztobirService.CityService.GetAll(),
            };
            return View(cities);
        }
        [Route("/admin/city/create/")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("/admin/city/create/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityCreateVM city)
        {
            var model = await _aztobirService.CityService.Create(city);
            if (model != "ok")
            {
                ModelState.AddModelError(string.Empty, model);
                return View(city);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [Route("/admin/city/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var city = await _aztobirService.CityService.Get(id);
                return View(city);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Route("/admin/city/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CityUpdateVM city)
        {
            try
            {
                var model = await _aztobirService.CityService.Update(id, city);
                if (model != "ok")
                {
                    ModelState.AddModelError(string.Empty, model);
                    return View(city);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
        [Route("/admin/city/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.CityService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
    }
}
