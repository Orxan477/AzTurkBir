namespace Aztobir.Core.Interfaces
{
    public interface ICRUDRepository<TEntity>
    {
        Task CreateAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
