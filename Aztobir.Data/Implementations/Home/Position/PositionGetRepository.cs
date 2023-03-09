using Aztobir.Core.Interfaces.Home.Position;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.Position
{
    public class PositionGetRepository:GetRepository<Core.Models.Position>,IPositionGetRepository
    {
        private AppDbContext _context;
        public PositionGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
