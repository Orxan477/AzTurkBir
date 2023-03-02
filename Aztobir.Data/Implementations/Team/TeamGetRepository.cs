using Aztobir.Core.İnterfaces.Team;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Team
{
    public class TeamGetRepository:GetRepository<Core.Models.Team>,ITeamGetRepository
    {
        private AppDbContext _context;
        public TeamGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
