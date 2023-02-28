﻿using Aztobir.Business.Interfaces;
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
        public async Task<IActionResult> Index()
        {
            NewsViewVM news = new NewsViewVM()
            {
                News = await _aztobirService.NewsService.GetAll(),
            };
            return View(news);
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
