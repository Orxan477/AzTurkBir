namespace Aztobir.Core.Models
{
    public class UniversityForm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public int UniversityId { get; set; }
        public  University University { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate{ get; set; }
    }
}
