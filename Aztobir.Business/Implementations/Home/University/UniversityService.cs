using AutoMapper;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Home.University
{
    public class UniversityService : IUniversityService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UniversityService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<UniversityVM>> GetAll()
        {
            var dbUniversities = await _unitOfWork.UniversityGetRepository.GetAll(x => !x.IsDeleted,"City");
            List<UniversityVM> universities = _mapper.Map<List<UniversityVM>>(dbUniversities);
            return universities;
        }
    }
}
