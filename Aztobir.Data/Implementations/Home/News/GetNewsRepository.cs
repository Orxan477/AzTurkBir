using Aztobir.Core.İnterfaces.Home.News;
using Aztobir.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aztobir.Data.Implementations.Home.News
{
    public class GetNewsRepository:GetRepository<Core.Models.News>,IGetNewsRepository
    {
        private AppDbContext _context;
        public GetNewsRepository(AppDbContext context ):base(context)
        {
            _context = context;
        }

        public async Task<List<Core.Models.News>> GetAllRecent(Expression<Func<Core.Models.News, bool>> exp, Expression<Func<Core.Models.News, int>> descending, int skip, int take, params string[] includes)
        {
            var query = GetQuery(includes);
            return exp is null
                ? await query.OrderByDescending(descending).ToListAsync()
                : await query.Where(exp).OrderByDescending(descending).Skip(skip).Take(take).ToListAsync();
        }
        private IQueryable<Core.Models.News> GetQuery(string[] includes)
        {
            var query = _context.News.AsQueryable();

            if (!(includes is null))
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}
