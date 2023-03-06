﻿using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home;
using Aztobir.Business.ViewModels.Home.University;
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
        public async Task<IActionResult> Index()
        {
            UniversityViewVM universityView = new UniversityViewVM()
            {
                Universities = await _aztobirService.UniversityService.GetAll(),
            };
            return View(universityView);
        }
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                UniversityViewVM universityView = new UniversityViewVM()
                {
                    University = await _aztobirService.UniversityService.Get(id),
                    Faculties = await _aztobirService.UniversityService.GetFaculties(id),
                    Photos = await _aztobirService.UniversityService.GetPhotos(id),
                    Feedbacks = await _aztobirService.UniversityService.GetFeedbacks(id),
                };
                return View(universityView);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
    }
}
