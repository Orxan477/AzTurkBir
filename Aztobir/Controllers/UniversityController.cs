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
            int count = int.Parse("6");
            //int count = int.Parse(GetSetting("TakeCount"));
            ViewBag.TakeCount = count;
            var products = _context.Universities
                                 .Where(x => !x.IsDeleted)
                                 .OrderByDescending(x => x.Id)
                                 .Skip((page - 1) * count)
                                 .Take(count)
                                 .ToList();
            //List<Product>products1= await  _repository.GetPaginate(count, page, "MenuImage,Category");
            //return Json(products1);

            var productsVM = GetProductList(products);
            int pageCount = GetPageCount(count);
            //Paginate<UniversityVM> model = new Paginate<UniversityVM>(productsVM, page, pageCount);
            //return Json(model);
            ////ViewBag.RestaurantName = GetSetting("RestaurantName");
            //return View(model);


            //UniversityViewVM universityView = new UniversityViewVM()
            //{
            //    Universities = new Paginate<UniversityVM>(productsVM, page, pageCount),
            //};
            return View();
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
