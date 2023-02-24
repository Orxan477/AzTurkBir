namespace Aztobir.Core.Models
{
    public class Feedback:BaseEntity
    {
        public string Comment { get; set; }
        public string Image { get; set; }
        public int UniversityId { get; set; }
    }
}
