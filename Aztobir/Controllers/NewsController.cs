using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.News;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class NewsController : Controller
    {
        private IMapper _mapper;
        private IAztobirService _aztobirService;
        private IUnitOfWork _unitOfWork;

        public NewsController(IAztobirService aztobirService,IMapper mapper)
        {
            _mapper = mapper;
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var newsDetail = await _aztobirService.NewsService.Get(id);
            News news = _mapper.Map<News>(newsDetail);
            news.IsDeleted = true;
            return Json(news);
            _unitOfWork.CRUDNewsRepository.DeleteAsync(news);
            await _unitOfWork.SaveChangesAsync();
            return Json("ok");  
            _aztobirService.NewsService.Delete(id);
            return Json("ok");
            try
            {
                return RedirectToAction("Index", "News", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
    }
}
