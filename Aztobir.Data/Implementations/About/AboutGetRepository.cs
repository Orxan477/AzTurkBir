using Aztobir.Core.İnterfaces.About;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.About
{
    public class AboutGetRepository : GetRepository<Core.Models.About>,IAboutGetRepository
    {
        private AppDbContext _context;
        public AboutGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
