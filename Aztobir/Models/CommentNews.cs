namespace Aztobir.UI.Models
{
    public class CommentNews:BaseEntity
    {
        public string Comment { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }   ////Website sorus
    }
}
