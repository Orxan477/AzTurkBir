using AutoMapper; 
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home;
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
        private IMapper _mapper;
        private AppDbContext _context;

        public UniversityController(IAztobirService aztobirService,IMapper mapper,AppDbContext context)
        {
            _aztobirService = aztobirService;
            _mapper = mapper;
            _context = context;
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
                    UniversityId = id,
                };
                return View(universityView);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(UniversityFormVM universityForm)
        {
            var model = await _aztobirService.UniversityFormService.Create(universityForm);
            if (model is null) return RedirectToAction("CustomBadRequest", "Error", new { area = "null" });
            return View(nameof(Index));
        }
    }
}
