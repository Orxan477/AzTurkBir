using Aztobir.Business.ViewModels.Home.City;

namespace Aztobir.Business.Interfaces.Home.City
{
    public interface ICityService
    {
        Task<List<CityVM>> GetAll();
        Task<CityVM> Get(int id);
        Task Create(CityCreateVM city);
        Task Update(int id, CityVM city);
    }
}
