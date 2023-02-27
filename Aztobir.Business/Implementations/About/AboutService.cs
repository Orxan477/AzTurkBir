using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.ViewModels.About;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.Models;

namespace Aztobir.Business.Implementations.About
{
    public class AboutService : IAboutService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AboutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AboutVM> Get()
        {
            var about = await _unitOfWork.AboutGetRepository.Get(x => !x.IsDeleted);
            AboutVM aboutVM = _mapper.Map<AboutVM>(about);
            return aboutVM;
        }
    }
}
