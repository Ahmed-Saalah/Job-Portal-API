using JobPortal.Domain.Entities;
using JobPortal.Domain.Entities.Identity;

namespace JobPortal.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<AppUser> AppUsers { get; }
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<JobApplication> JobApplications { get; }
        IGenericRepository<Skill> Skills { get; }
        IGenericRepository<UserSkill> UserSkills { get; }
        IGenericRepository<JobSkill> JobSkills { get; }
        IGenericRepository<Company> Companies { get; }
        IGenericRepository<Category> Categories { get; }
        Task SaveAsync();
    }
}
