using AutoMapper;
using Aztobir.Business.Interfaces.Team;
using Aztobir.Business.ViewModels.Team;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Team
{
    public class TeamService : ITeamService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TeamService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TeamDetailVM> Get(int id)
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.Get(x => !x.IsDeleted && x.Id == id, "Position");
            if (dbTeam is null) throw new Exception("NotFound");
            TeamDetailVM teams = _mapper.Map<TeamDetailVM>(dbTeam);
            return teams;
        }

        public async Task<List<TeamVM>> GetAll()
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.GetAll(x => !x.IsDeleted,"Position");
            List<TeamVM> teams = _mapper.Map<List<TeamVM>>(dbTeam);
            return teams;
        }
    }
}
