namespace Aztobir.Core.Models
{
    public class UniversityFaculty
    {
        public int Id { get; set; }
        public int UniversityId { get; set; }
        public int FacultyId { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }
    }
}
