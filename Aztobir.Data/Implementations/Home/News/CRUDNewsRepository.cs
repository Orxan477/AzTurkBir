using Aztobir.Core.Interfaces.Home.News;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.News
{
    public class CRUDNewsRepository:CRUDRepository<Core.Models.News>,ICRUDNewsRepository
    {
        private AppDbContext _context;
        public CRUDNewsRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
