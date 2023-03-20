using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels;
using Aztobir.Business.ViewModels.Home;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Business.ViewModels.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aztobir.UI.Controllers
{
    public class UniversityController : Controller
    {
        private IAztobirService _aztobirService;
        private IMapper _mapper;
        private AppDbContext _context;

        public UniversityController(IAztobirService aztobirService, IMapper mapper, AppDbContext context)
        {
            _aztobirService = aztobirService;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int takeCount = int.Parse("3");
            //int count = int.Parse(GetSetting("TakeCount"));
            ViewBag.TakeCount = takeCount;
            var model = await _aztobirService.UniversityService.GetPaginete(page, takeCount);
            return View(model);
        }
        private int GetPageCount(int take)
        {
            var prodCount = _context.Feedbacks.Count();
            return (int)Math.Ceiling((decimal)prodCount / take);
        }
        private List<UniversityVM> GetProductList(List<University> uni)
        {
            List<UniversityVM> model = new List<UniversityVM>();
            foreach (var item in uni)
            {
                UniversityVM feedback = _mapper.Map<UniversityVM>(item);
                model.Add(feedback);
            }
            return model;
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
