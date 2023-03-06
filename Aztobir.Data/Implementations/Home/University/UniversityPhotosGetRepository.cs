using Aztobir.Core.Interfaces.Home.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class UniversityPhotosGetRepository:GetRepository<UniversityImages>,IUniversityPhotosGetRepository   
    {
        private AppDbContext _context;
        public UniversityPhotosGetRepository(AppDbContext context):base(context )
        {
            _context = context;
        }
    }
}
