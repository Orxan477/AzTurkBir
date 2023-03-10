using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.About;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.Implementations.About
{
    public class AboutService : IAboutService
    {
        private string _errorMessage;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AboutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AboutVM> Get()
        {
            var about = await _unitOfWork.AboutGetRepository.Get(x => !x.IsDeleted);
            AboutVM aboutVM = _mapper.Map<AboutVM>(about);
            return aboutVM;
        }

        public async Task<string> Update(AboutVM about,string env,int size)
        {
            var dbAbout = await _unitOfWork.AboutGetRepository.Get(x => !x.IsDeleted);
            if (dbAbout is null) throw new Exception("Not Found");
            if (about.Content.ToLower().Trim()!=dbAbout.Content.ToLower().Trim())
            {
                dbAbout.Content = about.Content;
            }
            if (!CheckImageValid(about.Photo, "image/", size))
            {
                return _errorMessage;
            }
            string image = await Extension.SaveFileAsync(about.Photo, env, "assets/img");
            dbAbout.Image = image;
            _unitOfWork.AboutCRUDRepository.UpdateAsync(dbAbout);
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
    }
}
