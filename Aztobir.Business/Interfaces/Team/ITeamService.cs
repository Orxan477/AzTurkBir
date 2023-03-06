using Aztobir.Business.ViewModels.Team;

namespace Aztobir.Business.Interfaces.Team
{
    public interface ITeamService
    {
        Task<List<TeamVM>> GetAll();
        Task<TeamDetailVM> Get(int id);
        Task Delete(int id);
    }
}
