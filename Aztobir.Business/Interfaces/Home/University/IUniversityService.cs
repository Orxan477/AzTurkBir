using Aztobir.Business.ViewModels.Home.University;

namespace Aztobir.Business.Interfaces.Home.University
{
    public interface IUniversityService
    {
        Task<List<UniversityVM>> GetAll();
    }
}
