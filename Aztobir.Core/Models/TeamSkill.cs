namespace Aztobir.Core.Models
{
    public class TeamSkill
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
