using Aztobir.Business.Interfaces;
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
            UniversityViewVM universityView = new UniversityViewVM()
            {
                University = await _aztobirService.UniversityService.Get(id),
                Faculties = await _aztobirService.UniversityService.GetFaculties(id),
            };
            return View(universityView);
        }
    }
}
