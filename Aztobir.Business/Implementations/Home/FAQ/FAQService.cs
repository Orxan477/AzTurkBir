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

        public FAQService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(CreateFAQVM create)
        {
            Core.Models.FAQ dbFaq = _mapper.Map<Core.Models.FAQ>(create);
            dbFaq.CreatedAt = DateTime.Now;
            await _unitOfWork.FaqCRUDRepository.CreateAsync(dbFaq);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Update(int id, UpdateFAQVM faq)
        {
            var dbFAQ = await _unitOfWork.FAQGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbFAQ is null) throw new Exception("Not Found");
            if (faq.Question != null)
            {
                if (dbFAQ.Question.Trim().ToLower() != faq.Question.Trim().ToLower())
                {
                    dbFAQ.Question = faq.Question;
                }
            }
            if (faq.Response != null)
            {

                if (dbFAQ.Response.Trim().ToLower() != faq.Response.Trim().ToLower())
                {
                    dbFAQ.Response = faq.Response;
                }
            }
            dbFAQ.UpdatedAt = DateTime.Now;
            _unitOfWork.FaqCRUDRepository.UpdateAsync(dbFAQ);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var dbFAQ = await _unitOfWork.FAQGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbFAQ is null) throw new Exception("Not Found");
            dbFAQ.IsDeleted = true;
            _unitOfWork.FaqCRUDRepository.DeleteAsync(dbFAQ);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<FAQVM> Get(int id)
        {
            var dbFAQ = await _unitOfWork.FAQGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbFAQ is null) throw new Exception("Not Found");
            FAQVM faq = _mapper.Map<FAQVM>(dbFAQ);
            return faq;
        }
        public async Task<UpdateFAQVM> GetUpdate(int id)
        {
            var dbCity = await _unitOfWork.FAQGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbCity is null) throw new Exception("Not Found");
            var city = _mapper.Map<UpdateFAQVM>(dbCity);
            return city;
        }
        public async Task<List<FAQVM>> GetAll()
        {
            var dbFAQ = await _unitOfWork.FAQGetRepository.GetAll(x => !x.IsDeleted, x => x.Id);
            List<FAQVM> faq = _mapper.Map<List<FAQVM>>(dbFAQ);
            return faq;
        }


    }
}
