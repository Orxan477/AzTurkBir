using AutoMapper;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.ViewModels.About;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;

namespace Aztobir.Business.Implementations.About
{
    public class GoalService : IGoalService
    {
        private IMapper _mapper;
        private IGetRepository<Goal> _getRepository;

        public GoalService(IGetRepository<Goal> getRepository,IMapper mapper)
        {
            _mapper = mapper;
            _getRepository = getRepository;
        }
        public async Task<List<GoalVM>> GetAll()
        {
           var goal= await _getRepository.GetAll(x => !x.IsDeleted);
            List<GoalVM> goalVM = _mapper.Map<List<GoalVM>>(goal);
            return goalVM;
            
        }
    }
}
