namespace Aztobir.Core.Models
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public IList<University>Universities{ get; set; }
    }
}
