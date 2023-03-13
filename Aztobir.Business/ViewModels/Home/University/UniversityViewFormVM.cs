namespace Aztobir.Business.ViewModels.Home.University
{
    public class UniversityViewFormVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string UniversityName{ get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
