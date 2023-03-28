using Aztobir.Business.ViewModels.Home.Faculty;

namespace Aztobir.Business.Interfaces.Home.Faculty
{
    public interface IFacultyService
    {
        Task<List<FacultyVM>> GetAll();
        Task<FacultyVM> Get(int id);
        Task<FacultyUpdateVM> GetUpdate(int id);
        Task<string> Create(FacultyCreateVM city);
        Task<string> Update(int id, FacultyUpdateVM city);
        Task Delete(int id);
    }
}
