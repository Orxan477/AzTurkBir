using Aztobir.Core.Interfaces.Setting;
using Aztobir.Core.Models;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Setting
{
    public class SettingRepository : GetRepository<Core.Models.Setting>, ISettingRepository
    {
        private AppDbContext _context;

        public SettingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Dictionary<string, string> GetSetting()
        {
            return _context.Settings.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
