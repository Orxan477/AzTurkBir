using Aztobir.Core.Interfaces.Home.Faculty;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations.Home.Faculty
{
    public class FacultyCRUDRepository:CRUDRepository<Core.Models.Faculty>,IFacultyCRUDRepository
    {
        private AppDbContext _context;
        public FacultyCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
