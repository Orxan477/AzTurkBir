using Aztobir.Business.ViewModels.Home.News;

namespace Aztobir.Business.Interfaces.Home.News
{
    public interface INewsService
    {
        Task<List<NewsVM>> GetAll();
        Task<NewsVM> Get(int id);
        //NewsVM Get(int id);
        Task Delete(int id);
    }
}
