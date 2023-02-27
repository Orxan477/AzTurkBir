using Aztobir.Core.İnterfaces.Home.University;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class GetFacultiesRepository:GetRepository<Faculty>,IGetFacultiesRepository
    {
        private AppDbContext _context;
        public GetFacultiesRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
