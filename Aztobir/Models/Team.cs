namespace Aztobir.UI.Models
{
    public class Team:BaseEntity
    {
        public string FullName { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
        //linkleri sorus
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; } 
        public string  Content { get; set; }
    }
}
