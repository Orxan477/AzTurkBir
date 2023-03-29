using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.News;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class NewsController : Controller
    {
        private IAztobirService _aztobirService;
        public NewsController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            int takeCount = int.Parse("3");
            //int count = int.Parse(GetSetting("TakeCount"));
            ViewBag.TakeCount = takeCount;
            var model = await _aztobirService.NewsService.GetPaginete(page, takeCount);
            ViewBag.News_Head = _aztobirService.SettingSerivice.GetSetting("News-Head");
            ViewBag.News_Content = _aztobirService.SettingSerivice.GetSetting("News-Content");
            return View(model);
        }
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                NewsViewVM news = new NewsViewVM()
                {
                    News = await _aztobirService.NewsService.GetAll(),
                    NewsDetail = await _aztobirService.NewsService.Get(id),
                    RecentNews= await _aztobirService.NewsService.GetTakeRecent(),
                };
                return View(news);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound","Error",new {area="null"});
            }
        }
    }
}
