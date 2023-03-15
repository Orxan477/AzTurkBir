using Aztobir.Business.ViewModels.Home.Position;

namespace Aztobir.Business.Interfaces.Home.Position
{
    public interface IPositionService
    {
        Task<PositionVM> Get(int id);
        Task<List<PositionVM>> GetAll();
        Task<string> Create(CreatePositionVM position);
        Task<string> Update(int id, UpdatePositionVM position);
        Task Delete(int id);
    }
}
