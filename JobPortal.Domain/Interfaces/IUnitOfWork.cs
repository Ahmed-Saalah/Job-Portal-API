using JobPortal.Domain.Entities;
using JobPortal.Domain.Entities.Identity;

namespace JobPortal.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGeneric<AppUser> AppUsers { get; }
        IGeneric<Job> Jobs { get; }
        IGeneric<JobApplication> JobApplications { get; }
        IGeneric<Skill> Skills { get; }
        IGeneric<UserSkill> UserSkills { get; }
        IGeneric<JobSkill> JobSkills { get; }
        IGeneric<Company> Companies { get; }
        IGeneric<Category> Categories { get; }
        IDapperRepository<Job> JobDapper { get; }
        IDapperRepository<JobApplication> JobApplicationDapper { get; }
        Task SaveAsync();
    }
}
