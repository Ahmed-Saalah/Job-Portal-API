using JobPortal.Domain.Entities;

namespace JobPortal.Application.DTOs.JopApllication
{
    /// <summary>
    /// DTO for updating only the job application status
    /// </summary>
    public record UpdateJobApplicationStatusDTO(ApplicationStatus Status);
}
