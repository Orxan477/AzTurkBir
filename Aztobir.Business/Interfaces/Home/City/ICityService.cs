using Aztobir.Business.ViewModels.Home.City;

namespace Aztobir.Business.Interfaces.Home.City
{
    public interface ICityService
    {
        Task<List<CityVM>> GetAll();
        Task<CityVM> Get(int id);
        Task<string> Create(CityCreateVM city);
        Task<string> Update(int id, CityUpdateVM city);
        Task Delete(int id);
    }
}
