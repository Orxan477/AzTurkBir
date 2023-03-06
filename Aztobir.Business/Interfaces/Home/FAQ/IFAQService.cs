using Aztobir.Business.ViewModels.Home.FAQ;

namespace Aztobir.Business.Interfaces.Home.FAQ
{
    public interface IFAQService
    {
        Task<List<FAQVM>> GetAll();
        Task<FAQVM> Get(int id);
        Task Delete(int id);
    }
}
