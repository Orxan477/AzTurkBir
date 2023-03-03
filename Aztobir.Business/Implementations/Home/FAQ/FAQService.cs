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

        public async Task<FAQVM> Get(int id)
        {
            var dbFAQ = await _unitOfWork.FAQGetRepository.Get(x => !x.IsDeleted && x.Id==id);
            if (dbFAQ is null) throw new Exception("Not Found");
            FAQVM faq = _mapper.Map<FAQVM>(dbFAQ);
            return faq;
        }

        public async Task<List<FAQVM>> GetAll()
        {
            var dbFAQ = await _unitOfWork.FAQGetRepository.GetAll(x => !x.IsDeleted);
            List<FAQVM> faq = _mapper.Map<List<FAQVM>>(dbFAQ);
            return faq;
        }
    }
}
