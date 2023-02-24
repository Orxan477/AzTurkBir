using Microsoft.EntityFrameworkCore;

namespace Aztobir.Data.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {}
    }
}
