using AutoMapper;
using Aztobir.Business.Interfaces.Home.City;
using Aztobir.Business.ViewModels.Home.City;
using Aztobir.Core.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Implementations.Home.City
{
    public class CityService : ICityService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Create(CityCreateVM city)
        {
            bool isExist = _unitOfWork.CityCRUDRepository.Exist(x => x.Name == city.Name);
            if (!isExist)
            {
                Core.Models.City dbCity = _mapper.Map<Core.Models.City>(city);
                dbCity.CreatedAt = DateTime.Now;
                await _unitOfWork.CityCRUDRepository.CreateAsync(dbCity);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return "This name is exist";
            }
        }

        public async Task<string> Update(int id, CityUpdateVM city)
        {
            if (city.Name != null)
            {
                var dbCity = await _unitOfWork.CityGetRepository.Get(x => x.Id == id && !x.IsDeleted);
                if (dbCity is null) throw new Exception("Not Found");
                bool isExist = _unitOfWork.CityCRUDRepository.Exist(x => x.Name == city.Name);
                bool currentExist = dbCity.Name.Trim().ToLower() == city.Name.Trim().ToLower();
                if (isExist && !currentExist)
                {
                    return "This name is exist";
                }
                dbCity.Name = city.Name;
                dbCity.UpdatedAt = DateTime.Now;
                _unitOfWork.CityCRUDRepository.UpdateAsync(dbCity);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return "ok";
            }

        }
        public async Task Delete(int id)
        {
            var dbCity = await _unitOfWork.CityGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbCity is null) throw new Exception("Not Found");
            dbCity.IsDeleted = true;
            _unitOfWork.CityCRUDRepository.DeleteAsync(dbCity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CityVM> Get(int id)
        {
            var dbCity = await _unitOfWork.CityGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbCity is null) throw new Exception("Not Found");
            var city = _mapper.Map<CityVM>(dbCity);
            return city;
        }
        public async Task<CityUpdateVM> GetUpdate(int id)
        {
            var dbCity = await _unitOfWork.CityGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbCity is null) throw new Exception("Not Found");
            var city = _mapper.Map<CityUpdateVM>(dbCity);
            return city; 
        }

        public async Task<List<CityVM>> GetAll()
        {
            var dbCities = await _unitOfWork.CityGetRepository.GetAll(x => !x.IsDeleted, x => x.Id);
            if (dbCities is null) throw new Exception("Not Found");
            var cities = _mapper.Map<List<CityVM>>(dbCities);
            return cities;
        }


    }
}
