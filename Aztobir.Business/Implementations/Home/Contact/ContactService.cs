using AutoMapper;
using Aztobir.Business.Interfaces.Home.Contact;
using Aztobir.Business.ViewModels;
using Aztobir.Business.ViewModels.Home.Contact;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.İnterfaces;
using Microsoft.Extensions.Configuration;

namespace Aztobir.Business.Implementations.Home.Contact
{
    public class ContactService : IContactService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IConfiguration _configure;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configure)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configure = configure;
        }
        public async Task<string> Create(CreateContactVM contact)
        {
            int count = 0;
            TryAgain:
            try
            {
                EmailService.Send(_configure.GetSection("EmailSettings:Mail").Value,
                           _configure.GetSection("EmailSettings:Passowrd").Value, _configure.GetSection("EmailSettings:ToMail").Value, contact.Message, "Aztobir Əlaqə");
            }
            catch (Exception ex)
            {
                count++;
                if (count!=3)
                {
                    goto TryAgain;
                }
                return "Bad Request";
            }
            var newForm = _mapper.Map<Core.Models.Contact>(contact);
            newForm.CreatedAt = DateTime.Now;
            await _unitOfWork.ContactCRUDRepositorys.CreateAsync(newForm);
            await _unitOfWork.SaveChangesAsync();
            return "OK";
        }
        public async Task<string> SendMessage(int id, SendMessageVM message)
        {

            var dbForm = await _unitOfWork.ContactGetRepositorys.Get(x => !x.IsDeleted && x.Id == id);
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
            var dbForm = await _unitOfWork.ContactGetRepositorys.Get(x => !x.IsDeleted && x.Id == id);
            if (dbForm is null) throw new Exception("Not Found");
            dbForm.IsDeleted = true;
            _unitOfWork.ContactCRUDRepositorys.DeleteAsync(dbForm);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ContactVM> Get(int id)
        {
            var dbForm = await _unitOfWork.ContactGetRepositorys.Get(x => !x.IsDeleted && x.Id == id);
            if (dbForm is null) throw new Exception("Not Found");
            ContactVM form = _mapper.Map<ContactVM>(dbForm);
            return form;
        }

        public async Task<List<ContactVM>> GetAll()
        {
            var dbForm = await _unitOfWork.ContactGetRepositorys.GetAll(x => !x.IsDeleted, x => x.Id);
            List<ContactVM> forms = _mapper.Map<List<ContactVM>>(dbForm);
            return forms;
        }

        public async Task<Paginate<ContactVM>> GetPaginete(int page, int take)
        {
            var model = await _unitOfWork.ContactGetRepositorys.GetPaginateProducts(x => !x.IsDeleted, x => x.Id,page, take);

            var productsVM = GetProductList(model);
            var dbForm = await _unitOfWork.ContactGetRepositorys.GetAll(x => !x.IsDeleted, x => x.Id);
            int pageCount = GetPageCount(take, dbForm);
            return new Paginate<ContactVM>(productsVM, page, pageCount);

        }
        private int GetPageCount(int take, List<Core.Models.Contact> contacts)
        {
            var prodCount = contacts.Count();
            return (int)Math.Ceiling((decimal)prodCount / take);
        }
        private List<ContactVM> GetProductList(List<Core.Models.Contact> contact)
        {
            List<ContactVM> model = new List<ContactVM>();
            foreach (var item in contact)
            {
                ContactVM feedback = _mapper.Map<ContactVM>(item);
                model.Add(feedback);
            }
            return model;
        }
    }
}