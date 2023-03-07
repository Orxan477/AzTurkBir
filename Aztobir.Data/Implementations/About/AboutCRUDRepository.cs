using Aztobir.Core.Interfaces.About;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations.About
{
    public class AboutCRUDRepository:CRUDRepository<Core.Models.About>,IAboutCRUDRepository
    {
        private AppDbContext _context;
        public AboutCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
