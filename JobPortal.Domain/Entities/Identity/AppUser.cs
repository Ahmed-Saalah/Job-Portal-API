using Microsoft.AspNetCore.Identity;

namespace JobPortal.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
        public string? ProfileImageUrl { get; set; }
        public string? Location { get; set; }
        public string? ResumeUrl { get; set; }
        public string? Education { get; set; }
        public ICollection<UserSkill>? UserSkills { get; set; }
        public ICollection<JobApplication>? JobApplications { get; set; }
    }
}
