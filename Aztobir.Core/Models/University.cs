namespace Aztobir.Core.Models
{
    public class University : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string DilHazirlikEgitimi { get; set; }
        public string Image { get; set; }
        public int StudentCount { get; set; }
        public int FacultyCount { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public IList<Faculty> Faculties { get; set; }
        public IList<Feedback> Feedbacks{ get; set; }
    }
}
