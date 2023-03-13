using Aztobir.Core.Interfaces.Home.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class CRUDUnivertsityFormRepository:CRUDRepository<UniversityForm>,ICRUDUnivertsityFormRepository
    {
        private AppDbContext _context;
        public CRUDUnivertsityFormRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
