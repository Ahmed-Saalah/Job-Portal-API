using JobPortal.Domain.Entities;

namespace JobPortal.Application.DTOs.JopApllication
{
    /// <summary>
    /// DTO for updating only the job application status
    /// </summary>
    public class UpdateJobApplicationStatusDTO
    {
        public required ApplicationStatus Status { get; set; }
    }
}
