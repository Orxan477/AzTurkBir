using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.ViewModels.Team
{
    public class TeamDetailVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Linkedin { get; set; }
        public string Facebook { get; set; }
        public int PositionId { get; set; }
        public string Twitter { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public IFormFile Photo { get; set; }
    }
}
