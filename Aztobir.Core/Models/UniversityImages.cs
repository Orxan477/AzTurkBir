namespace Aztobir.Core.Models
{
    public class UniversityImages:BaseEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}
