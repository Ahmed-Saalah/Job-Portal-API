using JobPortal.Domain.Entities;
using JobPortal.Domain.Entities.Identity;
using JobPortal.Domain.Interfaces;
using JobPortal.Infrastructure.Data;

namespace JobPortal.Infrastructure.Repository
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public IGenericRepository<Job> Jobs { get; } = new GenericRepository<Job>(context);
        public IGenericRepository<JobApplication> JobApplications { get; } =
            new GenericRepository<JobApplication>(context);
        public IGenericRepository<Skill> Skills { get; } = new GenericRepository<Skill>(context);
        public IGenericRepository<UserSkill> UserSkills { get; } =
            new GenericRepository<UserSkill>(context);
        public IGenericRepository<JobSkill> JobSkills { get; } =
            new GenericRepository<JobSkill>(context);
        public IGenericRepository<AppUser> AppUsers { get; } =
            new GenericRepository<AppUser>(context);
        public IGenericRepository<Company> Companies { get; } =
            new GenericRepository<Company>(context);
        public IGenericRepository<Category> Categories { get; } =
            new GenericRepository<Category>(context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
