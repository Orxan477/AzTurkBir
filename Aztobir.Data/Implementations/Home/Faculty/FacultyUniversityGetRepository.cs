using Aztobir.Core.Interfaces.Home.Faculty;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aztobir.Data.Implementations.Home.Faculty
{
    public class FacultyUniversityGetRepository:GetRepository<Core.Models.FacultyUniversity>,IFacultyUniversityGetRepository
    {
        private AppDbContext _context;
        public FacultyUniversityGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<FacultyUniversity>> GetFacultiesUniversity(Expression<Func<FacultyUniversity, bool>> exp = null, params string[] includes)
        {
            var query = _context.FacultyUniversities.AsQueryable();

            if (!(includes is null))
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.Where(exp).ToListAsync();
        }
    }
}
