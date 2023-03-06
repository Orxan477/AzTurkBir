using AutoMapper;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Home.University
{
    public class UniversityService : IUniversityService
    {
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
            var dbFaculties = await _unitOfWork.GetFacultiesRepository.GetAll(x => x.UniversityId== id);
            if (dbFaculties is null) throw new Exception("Not Found");
            List<FacultiesVM> faculties = _mapper.Map<List<FacultiesVM>>(dbFaculties);
            return faculties;
        }

        public async Task<List<UniPhotosVM>> GetPhotos(int id)
        {
            var dbPhotos = await _unitOfWork.UniversityPhotosGetRepository.GetAll(x => x.UniversityId == id);
            if (dbPhotos is null) throw new Exception("Not Found");
            List<UniPhotosVM> photos = _mapper.Map<List<UniPhotosVM>>(dbPhotos);
            return photos;
        }
        public async Task<List<FeedbackVM>> GetFeedbacks(int id)
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.GetAll(x=>x.Id==id,"University");
            List<FeedbackVM> feedbacks = _mapper.Map<List<FeedbackVM>>(dbFeedback);
            return feedbacks;
        }
    }
}
