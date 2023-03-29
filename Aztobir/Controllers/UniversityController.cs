using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Business.ViewModels.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class UniversityController : Controller
    {
        private IAztobirService _aztobirService;

        public UniversityController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int takeCount = int.Parse("3");
            //int count = int.Parse(GetSetting("TakeCount"));
            ViewBag.TakeCount = takeCount;
            var model = await _aztobirService.UniversityService.GetPaginete(page, takeCount);
            ViewBag.Universitet_Head = _aztobirService.SettingSerivice.GetSetting("Universitet-Head");
            ViewBag.Universitet_Content = _aztobirService.SettingSerivice.GetSetting("Universitet-Content");
            return View(model);
        }
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                UniversityViewVM universityView = new UniversityViewVM()
                {
                    University = await _aztobirService.UniversityService.Get(id),
                    Faculties = await _aztobirService.UniversityService.GetFacultyNames(id),
                    Photos = await _aztobirService.UniversityService.GetPhotos(id),
                    UniversityId = id,
                };
                return View(universityView);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Detail(UniversityFormVM universityForm)
        //{
        //    var model = await _aztobirService.UniversityFormService.Create(universityForm);
        //    if (model is null) return RedirectToAction("CustomBadRequest", "Error", new { area = "null" });
        //    return View(nameof(Index));
        //}
    }
}
