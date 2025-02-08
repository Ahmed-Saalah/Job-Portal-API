namespace JobPortal.Application.DTOs.JopApllication
{
    public class JopApplicationBase
    {
        public string UserId { get; set; }
        public  Guid JobId { get; set; }
        public string ApplicantFirstName { get; set; } = string.Empty;
        public string ApplicantLastName { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string ResumeUrl { get; set; } = string.Empty;
    }
}
