using Aztobir.Core.Interfaces.Team;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Team
{
    public class TeamCRUDRepository:CRUDRepository<Core.Models.Team>,ITeamCRUDRepository
    {
        private AppDbContext _context;
        public TeamCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
