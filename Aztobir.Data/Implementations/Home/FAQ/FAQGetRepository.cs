using Aztobir.Core.İnterfaces.Home.FAQ;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.FAQ
{
    public class FAQGetRepository:GetRepository<Core.Models.FAQ>,IFAQGetRepository
    {
        private AppDbContext _context;
        public FAQGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
