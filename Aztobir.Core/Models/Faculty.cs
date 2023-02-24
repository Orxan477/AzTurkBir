namespace Aztobir.Core.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<University>Universities { get; set; }
    }
}
