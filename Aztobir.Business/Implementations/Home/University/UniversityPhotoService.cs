using AutoMapper;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.Implementations.Home.University
{
    public class UniversityPhotoService : IUniversityPhotoService
    {
        private string _errorMessage;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UniversityPhotoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Create(int id, CreateUniPhotosVM photos, string env,int size)
        {
            var dbPhoto = await _unitOfWork.UniversityGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbPhoto is null) throw new Exception("Not Found");
            foreach (var photo in photos.Photos)
            {
                if (!CheckImageValid(photo, "image/", size))
                {
                    return _errorMessage;
                }
                string image = await Extension.SaveFileAsync(photo, env, "assets/img");
                UniversityImages uniPhoto = new UniversityImages()
                {
                    Image = image,
                    UniversityId = id,
                    CreatedAt = DateTime.Now
                };
                await _unitOfWork.UniversityImagesCURDRepository.CreateAsync(uniPhoto);
            }
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        public async Task<string> Update(int id, UpdateUniversityPhotosVM photo, string env,int size)
        {
            var dbPhoto = await _unitOfWork.UniversityPhotosGetRepository.Get(x => x.Id == id);
            if (dbPhoto is null) throw new Exception("Not Found");
            if (!CheckImageValid(photo.Photo, "image/", size))
            {
                return _errorMessage;
            }
            string image = await Extension.SaveFileAsync(photo.Photo, env, "assets/img");
            dbPhoto.Image = image;
            dbPhoto.UpdatedAt = DateTime.Now;
            _unitOfWork.UniversityImagesCURDRepository.UpdateAsync(dbPhoto);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }

        public async Task Delete(int id)
        {
            var dbPhoto = await _unitOfWork.UniversityPhotosGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbPhoto is null) throw new Exception("Not Found");
            dbPhoto.IsDeleted = true;
            _unitOfWork.UniversityImagesCURDRepository.DeleteAsync(dbPhoto);
            await _unitOfWork.SaveChangesAsync();
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

        public async Task<UpdateUniversityPhotosVM> GetPhoto(int id)
        {
            var dbPhoto = await _unitOfWork.UniversityPhotosGetRepository.Get(x => x.Id == id);
            if (dbPhoto is null) throw new Exception("Not Found");
            UpdateUniversityPhotosVM photo = new UpdateUniversityPhotosVM()
            {
                Image = dbPhoto.Image
            };
            return photo;
        }
    }
}
