namespace JobPortal.Application.DTOs.Job
{
    public class UpdateJobDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Responsibilities { get; set; }
        public string? Requirements { get; set; }
        public string? EmploymentType { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? Location { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string? Status { get; set; }
    }
}
