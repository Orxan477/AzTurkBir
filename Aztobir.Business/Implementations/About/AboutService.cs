using AutoMapper;
using Aztobir.Business.Interfaces;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.ViewModels.About;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;

namespace Aztobir.Business.Implementations.About
{
    public class AboutService : IAboutService
    {
        private IGetRepository<Core.Models.About> _getRepository;
        private IMapper _mapper;

        public AboutService(IGetRepository<Core.Models.About> getRepository,IMapper mapper)
        {
            _getRepository = getRepository;
            _mapper = mapper;
        }
        public async Task<AboutVM> Get()
        {
            var about = await _getRepository.Get(x => !x.IsDeleted);
            AboutVM aboutVM = _mapper.Map<AboutVM>(about);
            return aboutVM;
        }
    }
}
