namespace Aztobir.UI.Models
{
    public class BaseEntity
    {
        public int İd { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool İsDeleted { get; set; }
    }
}
