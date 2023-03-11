using AutoMapper;
using Aztobir.Business.Interfaces.Setting;
using Aztobir.Business.ViewModels.Setting;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Setting
{
    public class SettingService : ISettingService

    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public SettingService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public string GetSetting(string key)
        {
            Dictionary<string, string> Settings = _unitOfWork.SettingRepository.GetSetting();
            return Settings[$"{key}"];
        }

        public async Task<SettingListVM> Setting(int id)
        {
            var dbSetting = await _unitOfWork.SettingRepository.Get(x => x.Id==id && !x.IsDeleted);
            SettingListVM setting = _mapper.Map<SettingListVM>(dbSetting);
            return setting;
        }

        public async Task<List<SettingListVM>> SettingList()
        {
            var dbSettings= await _unitOfWork.SettingRepository.GetAll(x => !x.IsDeleted);
            List<SettingListVM> settings = _mapper.Map<List<SettingListVM>>(dbSettings);
            return settings;
        }

        public async Task<string> Update(int id, SettingListVM setting)
        {
            var dbTeam = await _unitOfWork.SettingRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbTeam is null) throw new Exception("NotFound");
            if (dbTeam.Value.Trim().ToLower() != setting.Value.Trim().ToLower())
            {
                dbTeam.Value = setting.Value;
            }
            _unitOfWork.SettingCRUDRepository.UpdateAsync(dbTeam);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
