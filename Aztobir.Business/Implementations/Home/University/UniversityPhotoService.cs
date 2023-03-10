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
        public UniversityPhotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Create(int id, CreateUniPhotosVM photos, string env)
        {
            foreach (var photo in photos.Photos)
            {
                if (!CheckImageValid(photo, "image/", 200))
                {
                    return _errorMessage;
                }
                string image = await Extension.SaveFileAsync(photo, env, "assets/img");
                UniversityImages uniPhoto = new UniversityImages()
                {
                    Image=image,
                    UniversityId=id,
                    CreatedAt=DateTime.Now
                };
            await _unitOfWork.UniversityImagesCURDRepository.CreateAsync(uniPhoto);
            }
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        public Task<string> Update(int id, CreateUniPhotosVM photos, string env)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
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
