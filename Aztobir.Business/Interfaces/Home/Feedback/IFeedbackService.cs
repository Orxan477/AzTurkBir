using Aztobir.Business.ViewModels.Home.Feedback;

namespace Aztobir.Business.Interfaces.Home.Feedback
{
    public interface IFeedbackService
    {
        Task<List<FeedbackVM>> GetAll();
    }
}
