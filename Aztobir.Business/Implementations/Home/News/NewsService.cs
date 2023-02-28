﻿using AutoMapper;
using Aztobir.Business.Interfaces.Home.News;
using Aztobir.Business.ViewModels.Home.News;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Home.News
{
    public class NewsService : INewsService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public NewsService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NewsVM> Get(int id)
        {
            var dbNews = await _unitOfWork.GetNewsRepository.Get(x => !x.IsDeleted && x.Id == id);
            NewsVM news = _mapper.Map<NewsVM>(dbNews);
            return news;
        }

        public async Task<List<NewsVM>> GetAll()
        {
            var dbNews =await _unitOfWork.GetNewsRepository.GetAll(x => !x.IsDeleted);
            List<NewsVM> news = _mapper.Map<List<NewsVM>>(dbNews);
            return news;
        }
    }
}