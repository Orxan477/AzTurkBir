using AutoMapper;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.İnterfaces;
using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.Implementations.Home.University
{
    public class UniversityService : IUniversityService
    {
        private string _errorMessage;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UniversityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var dbUniversity = await _unitOfWork.UniversityGetRepository.Get(x => !x.IsDeleted && x.Id == id, "City");
            if (dbUniversity is null) throw new Exception("Not Found");
            dbUniversity.IsDeleted = true;
            _unitOfWork.CRUDUniversityRepository.DeleteAsync(dbUniversity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UniversityVM> Get(int id)
        {
            var dbUniversity = await _unitOfWork.UniversityGetRepository.Get(x => !x.IsDeleted && x.Id == id, "City");
            if (dbUniversity is null) throw new Exception("Not Found");
            UniversityVM university = _mapper.Map<UniversityVM>(dbUniversity);
            return university;
        }

        public async Task<List<UniversityVM>> GetAll()
        {
            var dbUniversities = await _unitOfWork.UniversityGetRepository.GetAll(x => !x.IsDeleted, "City");
            List<UniversityVM> universities = _mapper.Map<List<UniversityVM>>(dbUniversities);
            return universities;
        }

        public async Task<List<FacultiesVM>> GetFaculties(int id)
        {
            var dbFaculties = await _unitOfWork.GetFacultiesRepository.GetAll(x => x.UniversityId == id);
            if (dbFaculties is null) throw new Exception("Not Found");
            List<FacultiesVM> faculties = _mapper.Map<List<FacultiesVM>>(dbFaculties);
            return faculties;
        }

        public async Task<List<UniPhotosVM>> GetPhotos(int id)
        {
            var dbPhotos = await _unitOfWork.UniversityPhotosGetRepository.GetAll(x => !x.IsDeleted && x.UniversityId == id);
            if (dbPhotos is null) throw new Exception("Not Found");
            List<UniPhotosVM> photos = _mapper.Map<List<UniPhotosVM>>(dbPhotos);
            return photos;
        }
        public async Task<List<FeedbackVM>> GetFeedbacks(int id)
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.GetAll(x => x.Id == id, "University");
            List<FeedbackVM> feedbacks = _mapper.Map<List<FeedbackVM>>(dbFeedback);
            return feedbacks;
        }

        public async Task<string> Create(CreateUniversityVM uni, string env,int size)
        {
            var newUni = _mapper.Map<Core.Models.University>(uni);
            if (!CheckImageValid(uni.Photo, "image/", size))
            {
                return _errorMessage;
            }
            string image = await Extension.SaveFileAsync(uni.Photo, env, "assets/img");
            newUni.Image = image;
            newUni.CreatedAt = DateTime.Now;
            await _unitOfWork.CRUDUniversityRepository.CreateAsync(newUni);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }

        public async Task<string> Update(int id, UniversityVM uni, string env,int size)
        {
            var dbUni = await _unitOfWork.UniversityGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbUni is null) throw new Exception("Not Found");
            if (dbUni.Name.ToLower().Trim() != uni.Name.ToLower().Trim())
            {
                dbUni.Name = uni.Name;
            }
            if (dbUni.Content.ToLower().Trim() != uni.Content.ToLower().Trim())
            {
                dbUni.Content = uni.Content;
            }
            if (dbUni.StudentCount != uni.StudentCount)
            {
                dbUni.StudentCount = uni.StudentCount;
            }
            if (dbUni.FacultyCount != uni.FacultyCount)
            {
                dbUni.FacultyCount = uni.FacultyCount;
            }
            if (dbUni.EducationLanguage.ToLower().Trim() != uni.EducationLanguage.ToLower().Trim())
            {
                dbUni.EducationLanguage = uni.EducationLanguage;
            }
            if (dbUni.Status != uni.Status)
            {
                dbUni.Status = uni.Status;
            }
            if (uni.Photo != null)
            {
                if (!CheckImageValid(uni.Photo, "image/", size))
                {
                    return _errorMessage;
                }
                else
                {
                    string image = await Extension.SaveFileAsync(uni.Photo, env, "assets/img");
                    dbUni.Image = image;
                }
            }
            dbUni.UpdatedAt = DateTime.Now;
            dbUni.CityId = uni.CityId;
            _unitOfWork.CRUDUniversityRepository.UpdateAsync(dbUni);
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
