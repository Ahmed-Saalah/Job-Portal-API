namespace JobPortal.Domain.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } 
        public string? Responsibilities { get; set; }
        public string? Requirements { get; set; }
        public string? EmploymentType { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? Location { get; set; }
        public decimal? SalaryMin {  get; set; }
        public decimal? SalaryMax { get; set; }
        public string? Status { get; set; }
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        public Guid CategoryId {  get; set; }
        public Category? Category { get; set; }
        public ICollection<JobSkill>? JobSkills { get; set; }
        public required ICollection<JobApplication>? JobApplications { get; set; }
    }
}
