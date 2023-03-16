using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.News;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private IAztobirService _aztobirService;
        private IWebHostEnvironment _env;

        public NewsController(IAztobirService aztobirService, IWebHostEnvironment env)
        {
            _aztobirService = aztobirService;
            _env = env;
        }
        [Route("/admin/news/index")]
        public async Task<IActionResult> Index(int page=1)
        {

            int takeCount = int.Parse("3");
            //int count = int.Parse(GetSetting("TakeCount"));
            ViewBag.TakeCount = takeCount;
            var model = await _aztobirService.NewsService.GetPaginete(page, takeCount);
            return View(model);
        }
        [Route("/admin/news/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                NewsViewVM news = new NewsViewVM()
                {
                    News = await _aztobirService.NewsService.GetAll(),
                    NewsDetail = await _aztobirService.NewsService.Get(id),
                };
                return View(news);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "News", new { area = "admin" });
            }
        }
        [Route("/admin/news/create/")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("/admin/news/create/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsVM news)
        {
            if (!ModelState.IsValid) return View(news);
            var saveNews = await _aztobirService.NewsService.Create(news, _env.WebRootPath,PhotoSize());
            if (saveNews == "ok")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, saveNews);
                return View(news);
            }

        }
        [Route("/admin/news/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var model =await _aztobirService.NewsService.GetUpdate(id);
                return View(model);
            }
            catch (Exception ex)
            {

                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
            
        }
        [Route("/admin/news/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateNewsVM news)
        {
            try
            {
                var model = await _aztobirService.NewsService.Update(id, news, _env.WebRootPath,PhotoSize());
                if (model!="ok")
                {
                    ModelState.AddModelError(string.Empty, model);
                    return View(news);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
            [Route("/admin/news/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.NewsService.Delete(id);
                return RedirectToAction("Index", "News", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "News", new { area = "admin" });
            }

        }
        private int PhotoSize()
        {
            string photosize = _aztobirService.SettingSerivice.GetSetting("PhotoSize");
            return Convert.ToInt32(photosize);
        }
    }
}
