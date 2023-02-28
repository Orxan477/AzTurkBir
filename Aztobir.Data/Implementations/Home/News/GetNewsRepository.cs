using Aztobir.Core.İnterfaces.Home.News;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.News
{
    public class GetNewsRepository:GetRepository<Core.Models.News>,IGetNewsRepository
    {
        private AppDbContext _context;
        public GetNewsRepository(AppDbContext context ):base(context)
        {
            _context = context;
        }
    }
}
