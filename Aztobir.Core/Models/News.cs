namespace Aztobir.Core.Models
{
    public class News: BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public IList<CommentNews> CommentNews { get; set; }
    }
}
