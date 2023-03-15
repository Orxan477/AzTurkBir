using Aztobir.Business.ViewModels.Home.Contact;
using Aztobir.Business.ViewModels.Home.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Interfaces.Home.Contact
{
    public interface IContactService
    {
        Task<List<ContactVM>> GetAll();
        Task<ContactVM> Get(int id);
        Task<string> Create(CreateContactVM contact);
        Task<string> SendMessage(int id, SendMessageVM message);
        Task Delete(int id);
    }
}
