namespace Aztobir.Core.Models
{
    public class Position:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Team> Teams { get; set; }
    }
}
