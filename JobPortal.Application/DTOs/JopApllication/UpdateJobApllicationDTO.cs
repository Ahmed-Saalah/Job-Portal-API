namespace JobPortal.Application.DTOs.JopApllication
{
    /// <summary>
    /// DTO for updating job application details (excluding status)
    /// </summary>
    public class UpdateJobApllicationDTO : JopApplicationBase
    {
        public Guid Id { get; set; }
    }

}
