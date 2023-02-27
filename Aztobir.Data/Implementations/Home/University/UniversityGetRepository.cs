using Aztobir.Core.İnterfaces.Home;
using Aztobir.Core.İnterfaces.Home.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class UniversityGetRepository : GetRepository<Core.Models.University>, IUniversityGetRepository
    {
        private AppDbContext _context;
        public UniversityGetRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
