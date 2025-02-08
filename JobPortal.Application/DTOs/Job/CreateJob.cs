﻿namespace JobPortal.Application.DTOs.Job
{
    public class CreateJob : JobBase
    {
        public string? EmploymentType { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? Location { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string? Status { get; set; }
    }
}
