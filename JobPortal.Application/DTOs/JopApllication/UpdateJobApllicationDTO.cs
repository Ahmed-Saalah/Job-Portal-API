namespace JobPortal.Application.DTOs.JopApllication
{
    /// <summary>
    /// DTO for updating job application details (excluding status)
    /// </summary>
    public record UpdateJobApllicationDTO(
        string ApplicantFirstName,
        string ApplicantLastName,
        int YearsOfExperience,
        string ResumeUrl
    );
}
