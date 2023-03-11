using Aztobir.Business.ViewModels.Setting;

namespace Aztobir.Business.Interfaces.Setting
{
    public interface ISettingService
    {
        string GetSetting(string key);
        Task<List<SettingListVM>> SettingList();
        Task<SettingListVM> Setting(int id);
        Task<string> Update(int id, SettingListVM setting);
    }
}
