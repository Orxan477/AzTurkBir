using Aztobir.Business.ViewModels.Home.Feedback;

namespace Aztobir.Business.Interfaces.Home.Feedback
{
    public interface IFeedbackService
    {
        Task<List<FeedbackVM>> GetAll();
        Task<FeedbackVM> Get(int id);
        Task<string> Create(CreateFeedbackVM feedback,string env,int size);
        Task Update(int id,FeedbackVM feedback,string env,int size);
        Task Delete(int id);
    }
}
