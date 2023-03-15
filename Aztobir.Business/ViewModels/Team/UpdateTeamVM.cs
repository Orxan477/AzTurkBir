﻿using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Team
{
    public class UpdateTeamVM
    {
        public string FullName { get; set; }
        public int PositionId { get; set; }
        public string Linkedin { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public IFormFile Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}