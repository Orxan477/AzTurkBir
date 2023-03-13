using Aztobir.Core.Interfaces.Home.Contact;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations.Home.Contact
{
    public class ContactGetRepository:GetRepository<Core.Models.Contact>,IContactGetRepository
    {
        private AppDbContext _context;
        public ContactGetRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
