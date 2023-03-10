using Aztobir.Business.Interfaces.Setting;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Setting
{
    public class SettingService : ISettingService
    {
        private IUnitOfWork _unitOfWork;
        public SettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetSetting(string key)
        {
            Dictionary<string, string> Settings = _unitOfWork.SettingRepository.GetSetting();
            return Settings[$"{key}"];
        }
    }
}
