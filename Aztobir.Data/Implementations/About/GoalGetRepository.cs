using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.About
{
    public class GoalGetRepository:GetRepository<Goal>,IGoalGetRepository
    {
        private AppDbContext _context;
        public GoalGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
