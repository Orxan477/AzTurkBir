using Aztobir.Business.ViewModels.Home.News;

namespace Aztobir.Business.Interfaces.Home.News
{
    public interface INewsService
    {
        Task<List<NewsVM>> GetAll();
        Task<List<NewsVM>> GetTake(int count);
        Task<NewsVM> Get(int id);
        Task<UpdateNewsVM> GetUpdate(int id);
        Task<string> Create(CreateNewsVM news,string env,int size);
        Task<string> Update(int id, UpdateNewsVM news, string env,int size);

        Task Delete(int id);
    }
}
