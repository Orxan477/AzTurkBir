using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UniversityController : Controller
    {
        private IAztobirService _aztobirService;
        private IMapper _mapper;

        public UniversityController(IAztobirService aztobirService,IMapper mapper)
        {
            _aztobirService = aztobirService;
            _mapper = mapper;
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
        [Route("/admin/university/delete/{id}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.UniversityService.Delete(id);
                return RedirectToAction("Index", "University", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
