using Aztobir.Core.Interfaces.Home.Faculty;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations.Home.Faculty
{
    public class FacultyGetRepository:GetRepository<Core.Models.Faculty>,IFacultyGetRepository
    {
        private AppDbContext _context;
        public FacultyGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
