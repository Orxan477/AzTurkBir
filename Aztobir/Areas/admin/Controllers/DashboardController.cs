using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private IAztobirService _aztobirService;

        public DashboardController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
    [Route("/admin/")]
        public async Task<IActionResult> Index()
        {
            var dbUniversitites = await _aztobirService.UniversityService.GetAll();
            var dbUniversityContacts = await _aztobirService.UniversityFormService.GetAll();
            var dbNews = await _aztobirService.NewsService.GetAll();
            var dbContacts = await _aztobirService.ContactService.GetAll();
            DashboardVM dashboard = new DashboardVM()
            {
                Universities = dbUniversitites.Count(),
                UniContacts = dbUniversityContacts.Count(),
                News = dbNews.Count(),
                Contacts = dbContacts.Count()
            };
            return View(dashboard);
        }
    }
}
