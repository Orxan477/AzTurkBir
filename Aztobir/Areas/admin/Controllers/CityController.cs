using Aztobir.Business.Interfaces;
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
    }
}
