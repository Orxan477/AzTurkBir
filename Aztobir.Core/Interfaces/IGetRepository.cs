using System.Linq.Expressions;

namespace Aztobir.Core.İnterfaces
{
    public interface IGetRepository<TEntity>
    {
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> exp, Expression<Func<TEntity, int>> descending, params string[] includes);
        Task<List<TEntity>> GetPaginateProducts(Expression<Func<TEntity, bool>> exp, Expression<Func<TEntity,int>> descending, int page,int count, params string[] includes);
     
        Task<List<TEntity>> GetAllAdmin(Expression<Func<TEntity, bool>> date ,params string[] includes);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> exp=null , params string[] includes);
        Task<List<TEntity>> GetTake(Expression<Func<TEntity, bool>> exp, int count, params string[] includes);

        Task<TEntity> GetLatestFirstOrDefault(Expression<Func<TEntity, bool>> exp, Expression<Func<TEntity, int>> descending,  params string[] includes);
    }
}

