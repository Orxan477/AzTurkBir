namespace Aztobir.Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<City>Cities{ get; set; }
    }
}
