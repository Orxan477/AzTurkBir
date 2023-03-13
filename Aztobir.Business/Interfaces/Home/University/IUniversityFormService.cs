using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Business.ViewModels.University;

namespace Aztobir.Business.Interfaces.Home.University
{
    public interface IUniversityFormService
    {
        Task<List<UniversityViewFormVM>> GetAll();
        Task<UniversityViewFormVM> Get(int id);
        Task<string> Create(UniversityFormVM universityForm);
        Task Delete(int id);
    }
}
