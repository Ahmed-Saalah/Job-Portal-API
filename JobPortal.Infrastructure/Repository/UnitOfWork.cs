using JobPortal.Domain.Entities;
using JobPortal.Domain.Entities.Identity;
using JobPortal.Domain.Interfaces;
using JobPortal.Infrastructure.Data;

namespace JobPortal.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IDapperRepository<Job> _jobDapper;
        private readonly IDapperRepository<JobApplication> _jobApplicationDapper;

        public UnitOfWork(AppDbContext context, IDapperRepository<Job> jobDapper, IDapperRepository<JobApplication> jobApplicationDapper)
        {
            _context = context;
            _jobDapper = jobDapper;
            _jobApplicationDapper = jobApplicationDapper;

            Jobs = new GenericRepository<Job>(context, jobDapper);
            JobApplications = new GenericRepository<JobApplication>(context, jobApplicationDapper);
            Skills = new GenericRepository<Skill>(context, null);
            UserSkills = new GenericRepository<UserSkill>(context, null);
            JobSkills = new GenericRepository<JobSkill>(context, null);
            AppUsers = new GenericRepository<AppUser>(context, null);
            Companies = new GenericRepository<Company>(context, null);
            Categories = new GenericRepository<Category>(context, null);
        }

        public IGeneric<Job> Jobs { get; }
        public IGeneric<JobApplication> JobApplications { get; }
        public IGeneric<Skill> Skills { get; }
        public IGeneric<UserSkill> UserSkills { get; }
        public IGeneric<JobSkill> JobSkills { get; }
        public IGeneric<AppUser> AppUsers { get; }
        public IGeneric<Company> Companies { get; }
        public IGeneric<Category> Categories { get; }
        public IDapperRepository<Job> JobDapper => _jobDapper;
        public IDapperRepository<JobApplication> JobApplicationDapper => _jobApplicationDapper;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
