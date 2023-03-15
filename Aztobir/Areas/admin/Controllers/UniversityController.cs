using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UniversityController : Controller
    {
        private IAztobirService _aztobirService;
        private IWebHostEnvironment _env;

        public UniversityController(IAztobirService aztobirService,IWebHostEnvironment env)
        {
            _aztobirService = aztobirService;
            _env = env;
        }
        [Route("/admin/university/index")]
        public async Task<IActionResult> Index()
        {
            UniversityViewVM universityView = new UniversityViewVM()
            {
                Universities = await _aztobirService.UniversityService.GetAll(),
            };
            return View(universityView);
        }
        [Route("/admin/university/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                UniversityViewVM universityView = new UniversityViewVM()
                {
                    University = await _aztobirService.UniversityService.Get(id),
                    Faculties = await _aztobirService.UniversityService.GetFaculties(id),
                };
                return View(universityView);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "University", new { area = "admin" });
                
            }
        }
        [Route("/admin/university/create/")]
        public async Task<IActionResult> Create()
        {
            await GetSelectedItemAsync();
            return View();
        }
        [Route("/admin/university/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUniversityVM uni)
        {
            if (!ModelState.IsValid)
            {
                await GetSelectedItemAsync();
                return Json(uni);
            }
            var model =await _aztobirService.UniversityService.Create(uni, _env.WebRootPath,PhotoSize());
            if(model != "ok")
            {
                ModelState.AddModelError(string.Empty, model);
                await GetSelectedItemAsync();
                return View(uni);
            }
            return RedirectToAction("Index");
        }
        [Route("/admin/university/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var model = await _aztobirService.UniversityService.Get(id);
                await GetSelectedItemAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
        [Route("/admin/university/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateUniveresityVM uni)
        {
            try
            {
                var model = await _aztobirService.UniversityService.Update(id, uni, _env.WebRootPath,PhotoSize());
                if (model != "ok")
                {
                    ModelState.AddModelError(string.Empty, model);
                    await GetSelectedItemAsync();
                    return View(uni);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
        [Route("/admin/university/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.UniversityService.Delete(id);
                return RedirectToAction("Index", "University", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "University", new { area = "admin" });
            }

        }
        private async Task GetSelectedItemAsync()
        {
            ViewBag.city = new SelectList(await _aztobirService.CityService.GetAll(), "Id", "Name");
        }
        private int PhotoSize()
        {
            string photosize = _aztobirService.SettingSerivice.GetSetting("PhotoSize");
            return Convert.ToInt32(photosize);
        }
    }
}
