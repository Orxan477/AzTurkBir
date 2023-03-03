using Aztobir.Business.ViewModels.About;

namespace Aztobir.Business.Interfaces.About
{
    public interface IGoalService
    {
        Task<List<GoalVM>> GetAll();
        Task<GoalVM> Get(int id);
    }
}
