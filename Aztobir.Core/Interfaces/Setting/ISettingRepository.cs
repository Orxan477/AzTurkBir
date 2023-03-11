using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;

namespace Aztobir.Core.Interfaces.Setting
{
    public interface ISettingRepository : IGetRepository<Core.Models.Setting>
    {
        Dictionary<string, string> GetSetting();
    }
}
