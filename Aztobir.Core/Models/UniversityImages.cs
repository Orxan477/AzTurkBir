namespace Aztobir.Core.Models
{
    public class UniversityImages
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}
