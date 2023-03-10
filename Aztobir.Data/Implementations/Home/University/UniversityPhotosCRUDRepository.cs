using Aztobir.Core.Interfaces.Home.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class UniversityPhotosCRUDRepository:CRUDRepository<UniversityImages>,IUniversityPhotosCRUDRepository
    {
        private AppDbContext _context;
        public UniversityPhotosCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
