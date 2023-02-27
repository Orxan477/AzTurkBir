using AutoMapper;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.ViewModels.About;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.Models;

namespace Aztobir.Business.Implementations.About
{
    public class GoalService : IGoalService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public GoalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GoalVM>> GetAll()
        {
           var goal= await _unitOfWork.GoalGetRepository.GetAll(x => !x.IsDeleted);
            List<GoalVM> goalVM = _mapper.Map<List<GoalVM>>(goal);
            return goalVM;
            
        }
    }
}
