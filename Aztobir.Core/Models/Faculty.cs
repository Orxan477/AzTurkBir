namespace Aztobir.Core.Models
{
    public class Faculty:BaseEntity
    {
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}
