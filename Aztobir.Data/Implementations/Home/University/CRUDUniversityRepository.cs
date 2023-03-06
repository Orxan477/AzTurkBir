using Aztobir.Core.Interfaces.Home.University;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class CRUDUniversityRepository:CRUDRepository<Core.Models.University>,ICRUDUniversityRepository
    {
        private AppDbContext _context;
        public CRUDUniversityRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
