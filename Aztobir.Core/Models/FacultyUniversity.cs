using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Core.Models
{
    public class FacultyUniversity:BaseEntity
    {
        public int UniversityId { get; set; }
        public University University { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
