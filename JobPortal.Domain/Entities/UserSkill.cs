using JobPortal.Domain.Entities.Identity;

namespace JobPortal.Domain.Entities
{
    public class UserSkill
    {
        public string UserId { get; set; }
        public AppUser? User { get; set; }

        public Guid SkillId { get; set; }
        public Skill? Skill { get; set; }
    }
}
