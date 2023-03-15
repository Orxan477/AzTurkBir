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
        private IUnitOfWork _unitOfWork;

        public GoalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(GoalCreateVM goal)
        {
            Goal dbGoal= _mapper.Map<Goal>(goal);
            await _unitOfWork.GoalCRUDRepository.CreateAsync(dbGoal);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var dbGoal = await _unitOfWork.GoalGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbGoal is null) throw new Exception("Not Found");
            dbGoal.IsDeleted = true;
            _unitOfWork.GoalCRUDRepository.DeleteAsync(dbGoal);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GoalVM> Get(int id)
        {
            var goal = await _unitOfWork.GoalGetRepository.Get(x => !x.IsDeleted && x.Id==id);
            if (goal is null) throw new Exception("Not Found");
            GoalVM goalVM = _mapper.Map<GoalVM>(goal);
            return goalVM;
        }

        public async Task<List<GoalVM>> GetAll()
        {
           var goal= await _unitOfWork.GoalGetRepository.GetAll(x => !x.IsDeleted);
            List<GoalVM> goalVM = _mapper.Map<List<GoalVM>>(goal);
            return goalVM;
            
        }

        public async Task Update(int id, GoalUpdateVM goal)
        {
            var dbGoal = await _unitOfWork.GoalGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (goal.Logo != null)
            {
                if (dbGoal.Logo.Trim().ToLower() != goal.Logo.Trim().ToLower())
                {
                    dbGoal.Logo = goal.Logo;
                }
            }
            if (goal.Name != null)
            {
                if (dbGoal.Name.Trim().ToLower() != goal.Name.Trim().ToLower())
                {
                    dbGoal.Name = goal.Name;
                }
            }

            if (goal.Content != null)
            {
                if (dbGoal.Content.Trim().ToLower() != goal.Content.Trim().ToLower())
                {
                    dbGoal.Content = goal.Content;
                }
            }
            dbGoal.UpdatedAt = DateTime.Now;
            _unitOfWork.GoalCRUDRepository.UpdateAsync(dbGoal);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
