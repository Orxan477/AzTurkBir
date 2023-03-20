using System.Linq.Expressions;

namespace Aztobir.Core.İnterfaces.Home.News
{
    public interface IGetNewsRepository:IGetRepository<Models.News>
    {
        Task<List<Models.News>> GetAllRecent(Expression<Func<Models.News, bool>> exp, Expression<Func<Models.News, int>> descending, int skip, int take, params string[] includes);

    }
}
