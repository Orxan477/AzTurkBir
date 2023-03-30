using AutoMapper;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels;
using Aztobir.Business.ViewModels.Home.Faculty;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;
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
        public async Task<List<FacultyUniversityVM>> GetFacultyCount(int id)
        {
            var dbUniversity = await _unitOfWork.FacultyUniversitiesGetRepository.GetFacultiesUniversity(x => !x.IsDeleted && x.UniversityId == id);
            if (dbUniversity is null) throw new Exception("Not Found");
            List<FacultyUniversityVM> university = _mapper.Map<List<FacultyUniversityVM>>(dbUniversity);
            return university;
        }
        public async Task<List<FacultyVM>> GetFacultyNames(int id) 
        {
            List<FacultyVM> names=new List<FacultyVM>();
            var model = await GetFacultyCount(id);
            foreach (var item in model)
            {
                var modelFaculty=await _unitOfWork.FacultyGetRepository.Get(x => !x.IsDeleted && x.Id == item.FacultyId);
                FacultyVM modelFacultyVM = _mapper.Map<FacultyVM>(modelFaculty);
                names.Add(modelFacultyVM);
            }
            return names;
        }

        public async Task<List<UniversityVM>> GetAll()
        {
            var dbUniversities = await _unitOfWork.UniversityGetRepository.GetAll(x => !x.IsDeleted, x => x.Id, "City");
            List<UniversityVM> universities = _mapper.Map<List<UniversityVM>>(dbUniversities);
            return universities;
        }
        //duzelecek
        public async Task<List<FacultiesVM>> GetFaculties(int id)
        {
            //var dbFaculties = await _unitOfWork.GetFacultiesRepository.GetAll(x => x.Id);
            //if (dbFaculties is null) throw new Exception("Not Found");
            //List<FacultiesVM> faculties = _mapper.Map<List<FacultiesVM>>(dbFaculties);
            //return faculties;

            throw new NotImplementedException();
        }

        public async Task<List<UniPhotosVM>> GetPhotos(int id)
        {
            var dbPhotos = await _unitOfWork.UniversityPhotosGetRepository.GetAll(x => !x.IsDeleted && x.UniversityId == id, x => x.Id);
            if (dbPhotos is null) throw new Exception("Not Found");
            List<UniPhotosVM> photos = _mapper.Map<List<UniPhotosVM>>(dbPhotos);
            return photos;
        }
        public async Task<List<FeedbackVM>> GetFeedbacks(int id)
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.GetAll(x => x.Id == id, x => x.Id, "University");
            List<FeedbackVM> feedbacks = _mapper.Map<List<FeedbackVM>>(dbFeedback);
            return feedbacks;
        }

        public async Task<string> Create(CreateUniversityVM uni, string env, int size)
        {
            var newUni = _mapper.Map<Core.Models.University>(uni);
            if (!CheckImageValid(uni.Photo, "image/", size))
            {
                return _errorMessage;
            }
            string image = await Extension.SaveFileAsync(uni.Photo, env, "assets/img");
            if (!CheckImageValid(uni.PhotoHead, "image/", size))
            {
                return _errorMessage;
            }
            string imageHead = await Extension.SaveFileAsync(uni.PhotoHead, env, "assets/img");
            newUni.Image = image;
            newUni.ImageHead = imageHead;
            newUni.CreatedAt = DateTime.Now;
            await _unitOfWork.CRUDUniversityRepository.CreateAsync(newUni);
            await _unitOfWork.SaveChangesAsync();
            var latestUni = await _unitOfWork.UniversityGetRepository.GetLatestFirstOrDefault(x => !x.IsDeleted, x => x.Id);
            foreach (var facultyId in uni.FacultiesId)
            {
                FacultyUniversity faculty = new FacultyUniversity()
                {
                    FacultyId = facultyId,
                    UniversityId = latestUni.Id,
                    CreatedAt= DateTime.Now,
                };
                await _unitOfWork.FacultyUniversitiesCRUDRepository.CreateAsync(faculty);
            }
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }

        public async Task<string> Update(int id, UpdateUniveresityVM uni, string env, int size)
        {
            var dbUni = await _unitOfWork.UniversityGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbUni is null) throw new Exception("Not Found");
            if (uni.Name != null)
            {
                if (dbUni.Name.ToLower().Trim() != uni.Name.ToLower().Trim())
                {
                    dbUni.Name = uni.Name;
                }
            }
            if (uni.Content != null)
            {
                if (dbUni.Content.ToLower().Trim() != uni.Content.ToLower().Trim())
                {
                    dbUni.Content = uni.Content;
                }
            }
            if (uni.EducationPlan != null)
            {
                if (dbUni.EducationPlan.ToLower().Trim() != uni.EducationPlan.ToLower().Trim())
                {
                    dbUni.EducationPlan = uni.EducationPlan;
                }
            }
            if (dbUni.StudentCount != uni.StudentCount)
            {
                dbUni.StudentCount = uni.StudentCount;
            }
            if (dbUni.FacultyCount != uni.FacultyCount)
            {
                dbUni.FacultyCount = uni.FacultyCount;
            }
            if (uni.EducationLanguage != null)
            {
                if (dbUni.EducationLanguage.ToLower().Trim() != uni.EducationLanguage.ToLower().Trim())
                {
                    dbUni.EducationLanguage = uni.EducationLanguage;
                }
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
            if (uni.PhotoHead != null)
            {
                if (!CheckImageValid(uni.PhotoHead, "image/", size))
                {
                    return _errorMessage;
                }
                else
                {
                    string image = await Extension.SaveFileAsync(uni.PhotoHead, env, "assets/img");
                    dbUni.ImageHead = image;
                }
            }
            if (uni.FacultiesId != null)
            {
                var model = await _unitOfWork.FacultyUniversitiesGetRepository.GetFacultiesUniversity(x => x.UniversityId == dbUni.Id&& !x.IsDeleted);
                foreach (var item in model)
                {
                    item.IsDeleted = true;
                    _unitOfWork.FacultyUniversitiesCRUDRepository.DeleteAsync(item);
                }

                foreach (var facultyId in uni.FacultiesId)
                {
                    FacultyUniversity faculty = new FacultyUniversity()
                    {
                        FacultyId = facultyId,
                        UniversityId = dbUni.Id,
                        CreatedAt = DateTime.Now,
                    };
                    await _unitOfWork.FacultyUniversitiesCRUDRepository.CreateAsync(faculty);
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

        public async Task<Paginate<UniversityVM>> GetPaginete(int page, int take)
        {
            var model = await _unitOfWork.UniversityGetRepository.GetPaginateProducts(x => !x.IsDeleted, x => x.Id, page, take);
            var productsVM = GetProductList(model);
            var dbForm = await _unitOfWork.UniversityGetRepository.GetAll(x => !x.IsDeleted, x => x.Id);
            int pageCount = GetPageCount(take, dbForm);
            return new Paginate<UniversityVM>(productsVM, page, pageCount);
        }
        private int GetPageCount(int take, List<Core.Models.University> contacts)
        {
            var prodCount = contacts.Count();
            return (int)Math.Ceiling((decimal)prodCount / take);
        }
        private List<UniversityVM> GetProductList(List<Core.Models.University> contact)
        {
            List<UniversityVM> model = new List<UniversityVM>();
            foreach (var item in contact)
            {
                UniversityVM feedback = _mapper.Map<UniversityVM>(item);
                model.Add(feedback);
            }
            return model;
        }
    }
}
