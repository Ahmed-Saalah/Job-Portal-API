using JobPortal.Domain.Consts;
using JobPortal.Domain.Entities.Identity;

namespace JobPortal.Domain.Entities
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public required string UserId { get; set; }
        public AppUser? User { get; set; }
        public required Guid JobId { get; set; }
        public Job? Job { get; set; }

        public required string ApplicantFirstName { get; set; } = string.Empty;
        public required string ApplicantLastName { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string ResumeUrl { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = ApplicationStatus.Pending;
    }
}
