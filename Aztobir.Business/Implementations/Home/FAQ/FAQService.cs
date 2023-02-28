using AutoMapper;
using Aztobir.Business.Interfaces.Home.FAQ;
using Aztobir.Business.ViewModels.Home.FAQ;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Home.FAQ
{
    public class FAQService : IFAQService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FAQService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<FAQVM>> GetAll()
        {
            var dbFAQ = await _unitOfWork.FAQGetRepository.GetAll(x => !x.IsDeleted);
            List<FAQVM> faq = _mapper.Map<List<FAQVM>>(dbFAQ);
            return faq;
        }
    }
}
