using Aztobir.Business.ViewModels.Team;
 
namespace Aztobir.Business.Interfaces.Team
{
    public interface ITeamService
    {
        Task<List<TeamVM>> GetAll();
        Task<TeamDetailVM> Get(int id);
        Task<string> Create(CreateTeamVM team, string env);
        Task<string> Update(int id, TeamDetailVM team, string env);
        Task Delete(int id);
    }
}
