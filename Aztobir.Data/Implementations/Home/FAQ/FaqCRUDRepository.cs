using Aztobir.Core.Interfaces.Home.FAQ;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.FAQ
{
    public class FaqCRUDRepository:CRUDRepository<Core.Models.FAQ>,IFaqCRUDRepository
    {
        private AppDbContext _context;
        public FaqCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
