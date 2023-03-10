using Aztobir.Core.Interfaces;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations
{
    public class SettingRepository : ISettingRepository
    {
        private AppDbContext _context;

        public SettingRepository(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string, string> GetSetting()
        {
            return _context.Settings.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
