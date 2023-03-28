using Aztobir.Core.İnterfaces.Home.University;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.University
{
    public class GetFacultiesRepository:GetRepository<Core.Models.Faculty>,IGetFacultiesRepository
    {
        private AppDbContext _context;
        public GetFacultiesRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
