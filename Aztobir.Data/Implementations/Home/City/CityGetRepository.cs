using Aztobir.Core.Interfaces.Home.City;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Home.City
{
    public class CityGetRepository:GetRepository<Core.Models.City>, ICityGetRepository
    {
        private AppDbContext _context;
        public CityGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
