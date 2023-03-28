using AutoMapper;
using Aztobir.Business.Interfaces.Home.Faculty;
using Aztobir.Business.ViewModels.Home.Faculty;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Home.Faculty
{
    public class FacultyService : IFacultyService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public FacultyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Create(FacultyCreateVM faculty)
        {
            bool isExist = _unitOfWork.FacultyCRUDRepository.Exist(x => x.Name == faculty.Name);
            if (!isExist)
            {
                Core.Models.Faculty dbFaculty = _mapper.Map<Core.Models.Faculty>(faculty);
                dbFaculty.CreatedAt = DateTime.Now;
                await _unitOfWork.FacultyCRUDRepository.CreateAsync(dbFaculty);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return "This name is exist";
            }
        }
        public async Task<string> Update(int id, FacultyUpdateVM faculty)
        {
            if (faculty.Name != null)
            {
                var dbFaculty = await _unitOfWork.FacultyGetRepository.Get(x => x.Id == id && !x.IsDeleted);
                if (dbFaculty is null) throw new Exception("Not Found");
                bool isExist = _unitOfWork.FacultyCRUDRepository.Exist(x => x.Name == faculty.Name);
                bool currentExist = dbFaculty.Name.Trim().ToLower() == faculty.Name.Trim().ToLower();
                if (isExist && !currentExist)
                {
                    return "This name is exist";
                }
                dbFaculty.Name = faculty.Name;
                dbFaculty.UpdatedAt = DateTime.Now;
                _unitOfWork.FacultyCRUDRepository.UpdateAsync(dbFaculty);
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
            var dbFaculty = await _unitOfWork.FacultyGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbFaculty is null) throw new Exception("Not Found");
            dbFaculty.IsDeleted = true;
            _unitOfWork.FacultyCRUDRepository.DeleteAsync(dbFaculty);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<FacultyVM> Get(int id)
        {
            var dbFaculty = await _unitOfWork.FacultyGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbFaculty is null) throw new Exception("Not Found");
            var city = _mapper.Map<FacultyVM>(dbFaculty);
            return city;
        }

        public async Task<List<FacultyVM>> GetAll()
        {
            var dbFaculty = await _unitOfWork.FacultyGetRepository.GetAll(x => !x.IsDeleted, x => x.Id);
            if (dbFaculty is null) throw new Exception("Not Found");
            var faculties = _mapper.Map<List<FacultyVM>>(dbFaculty);
            return faculties;
        }

        public async Task<FacultyUpdateVM> GetUpdate(int id)
        {
            var dbFaculty = await _unitOfWork.FacultyGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbFaculty is null) throw new Exception("Not Found");
            var city = _mapper.Map<FacultyUpdateVM>(dbFaculty);
            return city;
        }

    }
}
