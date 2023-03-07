using Aztobir.Core.Interfaces.Home.City;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations.Home.City
{
    public class CityCRUDRepository:CRUDRepository<Core.Models.City>,ICityCRUDRepository
    {
        private AppDbContext _context;
        public CityCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
