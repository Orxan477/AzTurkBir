using Aztobir.Business.ViewModels.About;

namespace Aztobir.Business.Interfaces.About
{
    public interface IGoalService
    {
        Task<List<GoalVM>> GetAll();
        Task<GoalVM> Get(int id);
        Task Create(GoalCreateVM goal);
        Task Update(int id, GoalUpdateVM goal);
        Task Delete(int id);
    }
}
