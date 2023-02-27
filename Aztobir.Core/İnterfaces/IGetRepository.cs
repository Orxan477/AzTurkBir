using System.Linq.Expressions;

namespace Aztobir.Core.İnterfaces
{
    public interface IGetRepository<TEntity>
    {
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> exp ,params string[] includes);
        Task<List<TEntity>> GetAllAdmin(Expression<Func<TEntity, bool>> date ,params string[] includes);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> exp=null , params string[] includes);

    }
}
