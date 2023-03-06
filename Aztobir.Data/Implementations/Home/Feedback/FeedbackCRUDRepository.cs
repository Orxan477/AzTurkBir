using Aztobir.Core.Interfaces.Home.Feedback;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.Feedback
{
    public class FeedbackCRUDRepository:CRUDRepository<Core.Models.Feedback>,IFeedbackCRUDRepository
    {
        private AppDbContext _context;
        public FeedbackCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
