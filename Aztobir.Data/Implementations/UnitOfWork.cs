using Aztobir.Core.İnterfaces;
using Aztobir.Core.İnterfaces.About;
using Aztobir.Data.DAL;
using Aztobir.Data.Implementations.About;

namespace Aztobir.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private AboutGetRepository _aboutGetrepository;
        private GoalGetRepository _goalGetrepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IAboutGetRepository AboutGetRepository => _aboutGetrepository ?? new AboutGetRepository(_context);
        public IGoalGetRepository GoalGetRepository => _goalGetrepository ?? new GoalGetRepository(_context);

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
