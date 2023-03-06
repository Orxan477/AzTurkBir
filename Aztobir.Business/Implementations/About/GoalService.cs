using AutoMapper;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.ViewModels.About;
using Aztobir.Core.İnterfaces;

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

        public async Task<GoalVM> Get(int id)
        {
            var goal = await _unitOfWork.GoalGetRepository.Get(x => !x.IsDeleted && x.Id==id);
            GoalVM goalVM = _mapper.Map<GoalVM>(goal);
            return goalVM;
        }

        public async Task<List<GoalVM>> GetAll()
        {
           var goal= await _unitOfWork.GoalGetRepository.GetAll(x => !x.IsDeleted);
            List<GoalVM> goalVM = _mapper.Map<List<GoalVM>>(goal);
            return goalVM;
            
        }

        public async Task Update(int id, GoalVM goal)
        {
            var dbGoal = await _unitOfWork.GoalGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbGoal.Logo.Trim().ToLower()!=goal.Logo.Trim().ToLower())
            {
                dbGoal.Logo = goal.Logo;
            }
            if (dbGoal.Name.Trim().ToLower() != goal.Name.Trim().ToLower())
            {
                dbGoal.Name = goal.Name;
            }
            if (dbGoal.Content.Trim().ToLower() != goal.Content.Trim().ToLower())
            {
                dbGoal.Content = goal.Content;
            }
            dbGoal.UpdatedAt = DateTime.Now;
            _unitOfWork.GoalCRUDRepository.UpdateAsync(dbGoal);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
