using Aztobir.Core.Interfaces.Home.Position;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.Position
{
    public class PositionCRUDRepository:CRUDRepository<Core.Models.Position>,IPositionCRUDRepository
    {
        private AppDbContext _context;
        public PositionCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
