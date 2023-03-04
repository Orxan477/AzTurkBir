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
                return Json(ex.Message);
            }
        }
        [Route("/admin/news/delete/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.NewsService.Delete(id);
                return RedirectToAction("Index", "News", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
    }
}
