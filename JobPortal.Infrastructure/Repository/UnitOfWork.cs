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
            Companys = new GenericRepository<Company>(context);
            Categories = new GenericRepository<Category>(context);
        }

        public IGeneric<Job> Jobs { get; }

        public IGeneric<JobApplication> JobApplications { get; }

        public IGeneric<Skill> Skills { get; }

        public IGeneric<UserSkill> UserSkills { get; }

        public IGeneric<JobSkill> JobSkills { get; }

        public IGeneric<AppUser> AppUsers { get; }

        public IGeneric<Company> Companys { get; }

        public IGeneric<Category> Categories { get; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
