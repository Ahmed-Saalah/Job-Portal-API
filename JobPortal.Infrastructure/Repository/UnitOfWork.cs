using JobPortal.Domain.Entities;
using JobPortal.Domain.Entities.Identity;
using JobPortal.Domain.Interfaces;
using JobPortal.Infrastructure.Data;

namespace JobPortal.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Jobs = new GenericRepository<Job>(context);
            JobApplications = new GenericRepository<JobApplication>(context);
            Skills = new GenericRepository<Skill>(context);
            UserSkills = new GenericRepository<UserSkill>(context);
            JobSkills = new GenericRepository<JobSkill>(context);
            AppUsers = new GenericRepository<AppUser>(context);
            Companies = new GenericRepository<Company>(context);
            Categories = new GenericRepository<Category>(context);
        }

        public IGenericRepository<Job> Jobs { get; }
        public IGenericRepository<JobApplication> JobApplications { get; }
        public IGenericRepository<Skill> Skills { get; }
        public IGenericRepository<UserSkill> UserSkills { get; }
        public IGenericRepository<JobSkill> JobSkills { get; }
        public IGenericRepository<AppUser> AppUsers { get; }
        public IGenericRepository<Company> Companies { get; }
        public IGenericRepository<Category> Categories { get; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
