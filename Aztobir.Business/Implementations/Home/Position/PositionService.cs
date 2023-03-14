using AutoMapper;
using Aztobir.Business.Interfaces.Home.Position;
using Aztobir.Business.ViewModels.Home.Position;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;

namespace Aztobir.Business.Implementations.Home
{
    public class PositionService : IPositionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PositionService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PositionVM> Get(int id)
        {
            var dbPosition = await _unitOfWork.PositionGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbPosition is null) throw new Exception("Not Found");
            PositionVM position = _mapper.Map<PositionVM>(dbPosition);
            return position;
        }

        public async Task<List<PositionVM>> GetAll()
        {
            var dbPositions = await _unitOfWork.PositionGetRepository.GetAll(x=>!x.IsDeleted);
            List<PositionVM> positions = _mapper.Map<List<PositionVM>>(dbPositions);
            return positions;
        }
        public async Task<string> Create(CreatePositionVM position)
        {
            var newPosition = _mapper.Map<Position>(position);
            newPosition.CreatedAt = DateTime.Now;
            await _unitOfWork.PositionCRUDRepository.CreateAsync(newPosition);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }

        public async Task Delete(int id)
        {
            var dbPosition = await _unitOfWork.PositionGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            dbPosition.IsDeleted = true;
            _unitOfWork.PositionCRUDRepository.DeleteAsync(dbPosition);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<string> Update(int id, PositionVM position)
        {
            var dbPosition = await _unitOfWork.PositionGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbPosition is null) throw new Exception("Not Found");
            if (dbPosition.Name.ToLower().Trim() != position.Name.ToLower().Trim())
            {
                dbPosition.Name = position.Name;
            }
            dbPosition.UpdatedAt = DateTime.Now;
            _unitOfWork.PositionCRUDRepository.UpdateAsync(dbPosition);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
