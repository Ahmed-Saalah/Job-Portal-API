using JobPortal.Domain.Consts;

namespace JobPortal.Application.DTOs.JopApllication
{
    /// <summary>
    /// DTO for updating only the job application status
    /// </summary>
    public record UpdateJobApplicationStatusDTO(string Status);
}
