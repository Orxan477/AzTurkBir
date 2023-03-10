using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.ViewModels.Team
{
    public class CreateTeamVM
    {
        public string FullName { get; set; }
        public int PositionId { get; set; }
        public string Linkedin { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public IFormFile Photo{ get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}
