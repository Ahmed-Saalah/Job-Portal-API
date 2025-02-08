using JobPortal.Domain.Entities;

namespace JobPortal.Application.DTOs.JopApllication
{
    /// <summary>
    /// DTO for retrieving job application details
    /// </summary>
    public class GetJobApplicationDTO : JopApplicationBase
    {
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    }
}
