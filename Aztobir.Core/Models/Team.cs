﻿namespace Aztobir.Core.Models
{
    public class Team:BaseEntity
    {
        public string FullName { get; set; }        
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public string Linkedin { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string  Content { get; set; }
    }
}
