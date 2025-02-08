using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.Data.Configurations
{
    public class JobSkillsConfiguration : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> builder)
        {
            builder.HasKey(js => new {js.JobId, js.SkillId});

            builder.HasOne(js => js.Job)
                .WithMany(j => j.JobSkills) 
                .HasForeignKey(js => js.JobId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(js => js.Skill)
                .WithMany()  
                .HasForeignKey(js => js.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
