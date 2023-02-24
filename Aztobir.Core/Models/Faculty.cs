namespace Aztobir.Core.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}
