using Aztobir.Business.ViewModels.Home.News;

namespace Aztobir.Business.Interfaces.Home.News
{
    public interface INewsService
    {
        Task<List<NewsVM>> GetAll();
    }
}
