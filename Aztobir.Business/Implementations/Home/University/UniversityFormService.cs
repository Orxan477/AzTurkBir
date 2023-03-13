using AutoMapper;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Business.ViewModels.University;
using Aztobir.Core.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Implementations.Home.University
{
    public class UniversityFormService : IUniversityFormService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UniversityFormService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(UniversityFormVM universityForm)
        {
            var newForm = _mapper.Map<Core.Models.UniversityForm>(universityForm);
            newForm.CreatedDate = DateTime.Now;
            await _unitOfWork.CRUDUniversityFormRepository.CreateAsync(newForm);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var dbForm = await _unitOfWork.GetUniversityFormRepository.Get(x => !x.IsDeleted && x.Id == id, "University");
            if (dbForm is null) throw new Exception("Not Found");
            dbForm.IsDeleted = true;
            _unitOfWork.CRUDUniversityFormRepository.DeleteAsync(dbForm);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UniversityViewFormVM> Get(int id)
        {
            var dbForm = await _unitOfWork.GetUniversityFormRepository.Get(x => !x.IsDeleted && x.Id == id, "University");
            if (dbForm is null) throw new Exception("Not Found");
            UniversityViewFormVM form = _mapper.Map<UniversityViewFormVM>(dbForm);
            return form;
        }

        public async Task<List<UniversityViewFormVM>> GetAll()
        {
            var dbForm = await _unitOfWork.GetUniversityFormRepository.GetAll(x => !x.IsDeleted, "University");
            List<UniversityViewFormVM> forms = _mapper.Map<List<UniversityViewFormVM>>(dbForm);
            return forms;
        }
    }
}
