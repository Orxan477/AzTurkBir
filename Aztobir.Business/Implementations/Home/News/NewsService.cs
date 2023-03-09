using AutoMapper;
using Aztobir.Business.Interfaces.Home.News;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.Home.News;
using Aztobir.Core.İnterfaces;
using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.Implementations.Home.News
{
    public class NewsService : INewsService
    {
        private string _errorMessage;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateNewsVM news, string env)
        {
            var newNews = _mapper.Map<Core.Models.News>(news);
            if (!CheckImageValid(news.Photo, "image/", 200))
            {
                return _errorMessage;
            }
            string image = await Extension.SaveFileAsync(news.Photo, env, "assets/img");
            newNews.Image = image;
            newNews.CreatedAt = DateTime.Now;
            await _unitOfWork.CRUDNewsRepository.CreateAsync(newNews);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        public async Task<string> Update(int id, NewsVM news, string env)
        {
            var dbNews = await _unitOfWork.GetNewsRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbNews is null) throw new Exception("Not Found");
            if (dbNews.Name.ToLower().Trim() != news.Name.ToLower().Trim())
            {
                dbNews.Name = news.Name;
            }
            if (dbNews.Content.ToLower().Trim() != news.Content.ToLower().Trim())
            {
                dbNews.Content = news.Content;
            }
            if (news.Photo != null)
            {
                if (!CheckImageValid(news.Photo, "image/", 200))
                {
                    return _errorMessage;
                }
                else
                {
                    string image = await Extension.SaveFileAsync(news.Photo, env, "assets/img");
                    dbNews.Image = image;
                }
            }
            _unitOfWork.CRUDNewsRepository.UpdateAsync(dbNews);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        private bool CheckImageValid(IFormFile file, string type, int size)
        {
            if (!Extension.CheckType(file, type))
            {
                _errorMessage = "The type is not correct";
                return false;
            }
            if (!Extension.CheckSize(file, size))
            {
                _errorMessage = $"The size of this photo is {size}";
                return false;
            }
            return true;
        }

        public async Task Delete(int id)
        {
            var dbNews = await Get(id);
            var news = _mapper.Map<Core.Models.News>(dbNews);
            news.IsDeleted = true;
            _unitOfWork.CRUDNewsRepository.DeleteAsync(news);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<NewsVM> Get(int id)
        {
            var dbNews = await _unitOfWork.GetNewsRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbNews is null) throw new Exception("Not Found");
            NewsVM news = _mapper.Map<NewsVM>(dbNews);
            return news;
        }

        public async Task<List<NewsVM>> GetAll()
        {
            var dbNews = await _unitOfWork.GetNewsRepository.GetAll(x => !x.IsDeleted);
            List<NewsVM> news = _mapper.Map<List<NewsVM>>(dbNews);
            return news;
        }
    }
}
