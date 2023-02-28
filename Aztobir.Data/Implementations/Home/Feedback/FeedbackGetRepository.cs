using Aztobir.Core.İnterfaces.Home.Feedback;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.Feedback
{
    public class FeedbackGetRepository:GetRepository<Core.Models.Feedback>,IFeedbackGetRepository
    {
        private AppDbContext _context;
        public FeedbackGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
