using Aztobir.Core.Interfaces.Home.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class GetUnivertsityFormRepository:GetRepository<UniversityForm>,IGetUniversityFormRepository
    {
        private AppDbContext _context;
        public GetUnivertsityFormRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
