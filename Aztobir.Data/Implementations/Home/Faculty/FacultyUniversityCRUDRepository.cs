using Aztobir.Core.Interfaces.Home.Faculty;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.Faculty
{
    public class FacultyUniversityCRUDRepository:CRUDRepository<FacultyUniversity>,IFacultyUniversityCRUDRepository
    {
        private AppDbContext _context;
        public FacultyUniversityCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
