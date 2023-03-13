using Aztobir.Core.Interfaces.Home.Contact;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations.Home.Contact
{
    public class ContactCRUDRepository:CRUDRepository<Core.Models.Contact>,IContactCRUDRepository
    {
        private AppDbContext _context;
        public ContactCRUDRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
