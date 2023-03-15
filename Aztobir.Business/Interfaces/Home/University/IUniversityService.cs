using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.University;

namespace Aztobir.Business.Interfaces.Home.University
{
    public interface IUniversityService
    {
        Task<List<UniversityVM>> GetAll();
        Task<UniversityVM> Get(int id);
        Task<List<FacultiesVM>> GetFaculties(int id);
        Task<List<UniPhotosVM>> GetPhotos(int id);
        Task<List<FeedbackVM>> GetFeedbacks(int id);
        Task<string> Create(CreateUniversityVM uni,string env,int size);
        Task<string> Update(int id, UpdateUniveresityVM uni,string env,int size);
        Task Delete(int id);
    }
}
