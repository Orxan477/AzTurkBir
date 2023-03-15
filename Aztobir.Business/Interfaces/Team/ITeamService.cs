using Aztobir.Business.ViewModels.Team;
 
namespace Aztobir.Business.Interfaces.Team
{
    public interface ITeamService
    {
        Task<List<TeamVM>> GetAll();
        Task<TeamDetailVM> Get(int id);
        Task<string> Create(CreateTeamVM team, string env,int size);
        Task<string> Update(int id, UpdateTeamVM team, string env,int size);
        Task Delete(int id);
    }
}
