using Aztobir.Business.ViewModels;
using Aztobir.Business.ViewModels.Home.Feedback;

namespace Aztobir.Business.Interfaces.Home.Feedback
{
    public interface IFeedbackService
    {
        Task<List<FeedbackVM>> GetAll();
        Task<FeedbackVM> Get(int id);
        Task<UpdateFeedbackVM> GetUpdate(int id);
        Task<string> Create(CreateFeedbackVM feedback,string env,int size);
        Task<string> Update(int id, UpdateFeedbackVM feedback,string env,int size);
        Task<Paginate<FeedbackVM>> GetPaginete(int page, int take);

        Task Delete(int id);
    }
}
