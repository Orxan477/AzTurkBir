using AutoMapper;
using Aztobir.Business.Interfaces.Home.Contact;
using Aztobir.Business.ViewModels.Home.Contact;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Home.Contact
{
    public class ContactService : IContactService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(CreateContactVM contact)
        {
            var newForm = _mapper.Map<Core.Models.Contact>(contact);
            newForm.CreatedAt = DateTime.Now;
            await _unitOfWork.ContactCRUDRepositorys.CreateAsync(newForm);
            await _unitOfWork.SaveChangesAsync();
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
            var dbForm = await _unitOfWork.ContactGetRepositorys.GetAll(x => !x.IsDeleted);
            List<ContactVM> forms = _mapper.Map<List<ContactVM>>(dbForm);
            return forms;
        }
    }
}
