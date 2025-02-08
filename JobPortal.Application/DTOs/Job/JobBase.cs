using System.ComponentModel.DataAnnotations;

namespace JobPortal.Application.DTOs.Job
{
    public class JobBase
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Responsibilities { get; set; }
        public string? Requirements { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
