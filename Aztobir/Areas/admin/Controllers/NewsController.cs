using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {

        private IAztobirService _aztobirService;

        public NewsController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/news/index")]
        public async Task<IActionResult> Index()
        {
            NewsViewVM news = new NewsViewVM()
            {
                News = await _aztobirService.NewsService.GetAll(),
            };
            return View(news);
        }
    }
}
