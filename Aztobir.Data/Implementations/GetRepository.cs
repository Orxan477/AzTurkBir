using Aztobir.Core.İnterfaces;
using Aztobir.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aztobir.Data.Implementations
{
    public class GetRepository<TEntity> : IGetRepository<TEntity>
        where TEntity:class
    {
        private AppDbContext _context;

        public GetRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = GetQuery(includes);
            return await query.Where(exp).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            //int takeCount= Convert.ToInt32(take);
            
            var query = GetQuery(includes);
            return exp is null
                ? await query.ToListAsync()
                : await query.Where(exp).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAdmin(Expression<Func<TEntity, bool>> date, params string[] includes)
        {
            var query = GetQuery(includes);

            return  await query.OrderByDescending(date).ToListAsync();
        }
        private IQueryable<TEntity> GetQuery(string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

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
