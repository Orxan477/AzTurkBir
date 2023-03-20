using AutoMapper;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Business.ViewModels.University;
using Aztobir.Core.İnterfaces;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configure;

        public UniversityFormService(IUnitOfWork unitOfWork,IMapper mapper, IConfiguration configure)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configure = configure;
        }
        public async Task<string> Create(UniversityFormVM universityForm)
        {
            int count = 0;
        TryAgain:
            try
            {
                EmailService.Send(_configure.GetSection("EmailSettings:Mail").Value,
                           _configure.GetSection("EmailSettings:Passowrd").Value, _configure.GetSection("EmailSettings:ToMail").Value, universityForm.Message, "Aztobir University Message");
                return "ok";
            }
            catch (Exception ex)
            {
                count++;
                if (count != 3)
                {
                    goto TryAgain;
                }
                return "Bad Request";
            }
            var newForm = _mapper.Map<Core.Models.UniversityForm>(universityForm);
            newForm.CreatedDate = DateTime.Now;
            await _unitOfWork.CRUDUniversityFormRepository.CreateAsync(newForm);
            await _unitOfWork.SaveChangesAsync();
            return "OK";
        }
        public async Task<string> SendMessage(int id, SendMessageVM message)
        {
            
            var dbForm = await _unitOfWork.GetUniversityFormRepository.Get(x => !x.IsDeleted && x.Id == id, "University");
            if (dbForm is null) throw new Exception("Not Found");

            int count = 0;
        TryAgain:
            try
            {
                EmailService.Send(_configure.GetSection("EmailSettings:Mail").Value,
                           _configure.GetSection("EmailSettings:Passowrd").Value, dbForm.Email, message.Body, "Aztobir University Answer Message");
                await Delete(id);
                return "ok";
            }
            catch (Exception ex)
            {
                count++;
                if (count != 3)
                {
                    goto TryAgain;
                }
                return "Bad Request";
            }
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
            var dbForm = await _unitOfWork.GetUniversityFormRepository.GetAll(x => !x.IsDeleted, x => x.Id, "University");
            List<UniversityViewFormVM> forms = _mapper.Map<List<UniversityViewFormVM>>(dbForm);
            return forms;
        }
    }
}
