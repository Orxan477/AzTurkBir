using Aztobir.Core.Interfaces.About;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations.About
{
    public class GoalCRUDRepository:CRUDRepository<Core.Models.Goal>,IGoalCRUDRepository
    {
        private AppDbContext _context;
        public GoalCRUDRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
