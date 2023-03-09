using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.ViewModels.Home.Feedback
{
    public class CreateFeedbackVM
    {
        public string FullName { get; set; }
        public string Comment { get; set; }
        public int UniversityId { get; set; }
        public IFormFile Photo{ get; set; }
    }
}
