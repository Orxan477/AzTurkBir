﻿namespace Aztobir.Core.Models
{
    public class Feedback:BaseEntity
    {
        public string FullName { get; set; }
        public string Comment { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public string Image { get; set; }
    }
}
