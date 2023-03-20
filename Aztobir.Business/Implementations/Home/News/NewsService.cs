using AutoMapper;
using Aztobir.Business.Interfaces.Home.News;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels;
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

        public async Task<string> Create(CreateNewsVM news, string env,int size)
        {
            var newNews = _mapper.Map<Core.Models.News>(news);
            if (!CheckImageValid(news.Photo, "image/", size))
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
        public async Task<string> Update(int id, UpdateNewsVM news, string env,int size)
        {
            var dbNews = await _unitOfWork.GetNewsRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbNews is null) throw new Exception("Not Found");
            if (news.Name!= null)
            {
                if (dbNews.Name.ToLower().Trim() != news.Name.ToLower().Trim())
                {
                    dbNews.Name = news.Name;
                }
            }
            if(news.Content != null)
            {
                if (dbNews.Content.ToLower().Trim() != news.Content.ToLower().Trim())
                {
                    dbNews.Content = news.Content;
                }
            }
            if (news.Photo != null)
            {
                if (!CheckImageValid(news.Photo, "image/", size))
                {
                    return _errorMessage;
                }
                else
                {
                    string image = await Extension.SaveFileAsync(news.Photo, env, "assets/img");
                    dbNews.Image = image;
                }
            }
            dbNews.UpdatedAt = DateTime.Now;
            _unitOfWork.CRUDNewsRepository.UpdateAsync(dbNews);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        private bool CheckImageValid(IFormFile file, string type, int size)
        {
            if (!Extension.CheckType(file, type))
            {
                _errorMessage = "The image type is not correct";
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
        public async Task<UpdateNewsVM> GetUpdate(int id)
        {
            var dbCity = await _unitOfWork.GetNewsRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbCity is null) throw new Exception("Not Found");
            var city = _mapper.Map<UpdateNewsVM>(dbCity);
            return city;
        }
        public async Task<List<NewsVM>> GetAll()
        {
            var dbNews = await _unitOfWork.GetNewsRepository.GetAll(x => !x.IsDeleted, x => x.Id);
            List<NewsVM> news = _mapper.Map<List<NewsVM>>(dbNews);
            return news;
        }

        public async Task<List<NewsVM>> GetTake(int count)
        {
            var dbNews = await _unitOfWork.GetNewsRepository.GetTake(x => !x.IsDeleted,count);
            List<NewsVM> news = _mapper.Map<List<NewsVM>>(dbNews);
            return news;
        }
        public async Task<List<NewsVM>> GetTakeRecent()
        {
            var dbNews = await _unitOfWork.GetNewsRepository.GetAllRecent(x => !x.IsDeleted, x => x.Id, 1, 3);
            List<NewsVM> news = _mapper.Map<List<NewsVM>>(dbNews);
            return news;
        }

        public async Task<Paginate<NewsVM>> GetPaginete(int page, int take)
        {
            var model = await _unitOfWork.GetNewsRepository.GetPaginateProducts(x => !x.IsDeleted, x => x.Id, page, take);

            var productsVM = GetProductList(model);
            var dbForm = await _unitOfWork.GetNewsRepository.GetAll(x => !x.IsDeleted, x => x.Id);
            int pageCount = GetPageCount(take, dbForm);
            return new Paginate<NewsVM>(productsVM, page, pageCount);
        }
        private int GetPageCount(int take, List<Core.Models.News> contacts)
        {
            var prodCount = contacts.Count();
            return (int)Math.Ceiling((decimal)prodCount / take);
        }
        private List<NewsVM> GetProductList(List<Core.Models.News> contact)
        {
            List<NewsVM> model = new List<NewsVM>();
            foreach (var item in contact)
            {
                NewsVM feedback = _mapper.Map<NewsVM>(item);
                model.Add(feedback);
            }
            return model;
        }
    }
}
