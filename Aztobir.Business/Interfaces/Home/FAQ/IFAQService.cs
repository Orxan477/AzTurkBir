using Aztobir.Business.ViewModels.Home.FAQ;

namespace Aztobir.Business.Interfaces.Home.FAQ
{
    public interface IFAQService
    {
        Task<List<FAQVM>> GetAll();
        Task<FAQVM> Get(int id);
        Task<UpdateFAQVM> GetUpdate(int id);
        Task Create(CreateFAQVM create);
        Task Delete(int id);
        Task Update(int id, UpdateFAQVM faq);
    }
}
