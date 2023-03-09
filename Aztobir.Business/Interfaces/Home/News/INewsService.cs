using Aztobir.Business.ViewModels.Home.News;

namespace Aztobir.Business.Interfaces.Home.News
{
    public interface INewsService
    {
        Task<List<NewsVM>> GetAll();
        Task<NewsVM> Get(int id);
        //NewsVM Get(int id);
        Task<string> Create(CreateNewsVM news,string env);
        Task<string> Update(int id,NewsVM news, string env);

        Task Delete(int id);
    }
}
