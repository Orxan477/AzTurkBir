using AutoMapper;
using Aztobir.Business.Interfaces.Setting;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.Setting;
using Aztobir.Core.İnterfaces;
using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.Implementations.Setting
{
    public class SettingService : ISettingService

    {
        private string _errorMessage;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public SettingService(IUnitOfWork unitOfWork, IMapper mapper)
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
            var dbSetting = await _unitOfWork.SettingRepository.Get(x => x.Id == id && !x.IsDeleted);
            SettingListVM setting = _mapper.Map<SettingListVM>(dbSetting);
            return setting;
        }

        public async Task<List<SettingListVM>> SettingList()
        {
            var dbSettings = await _unitOfWork.SettingRepository.GetAll(x => !x.IsDeleted);
            List<SettingListVM> settings = _mapper.Map<List<SettingListVM>>(dbSettings);
            return settings;
        }

        public async Task<string> Update(int id, SettingListVM setting, string env, int size)
        {
            var dbSetting = await _unitOfWork.SettingRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbSetting is null) throw new Exception("NotFound");
            if (setting.Photo is null)
            {
                if (dbSetting.Value.Trim().ToLower() != setting.Value.Trim().ToLower())
                {
                    dbSetting.Value = setting.Value;
                }
            }
            else
            {
                if (!CheckImageValid(setting.Photo, "image/", size))
                {
                    return _errorMessage;
                }
                else
                {
                    string image = await Extension.SaveFileAsync(setting.Photo, env, "assets/img");
                    dbSetting.Value = image;
                }
            }
            _unitOfWork.SettingCRUDRepository.UpdateAsync(dbSetting);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        private bool CheckImageValid(IFormFile file, string type, int size)
        {
            if (!Extension.CheckType(file, type))
            {
                _errorMessage = "The type is not correct";
                return false;
            }
            if (!Extension.CheckSize(file, size))
            {
                _errorMessage = $"The size of this photo is {size}";
                return false;
            }
            return true;
        }
    }
}
