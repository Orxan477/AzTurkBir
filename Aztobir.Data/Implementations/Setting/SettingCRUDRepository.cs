using Aztobir.Core.Interfaces.Setting;
using Aztobir.Data.DAL;

namespace Aztobir.Data.Implementations.Setting
{
    public class SettingCRUDRepository:CRUDRepository<Core.Models.Setting>,ISettingCRUDRepository
    {
        private AppDbContext _context;
        public SettingCRUDRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
