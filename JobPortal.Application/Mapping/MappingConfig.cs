using JobPortal.Application.DTOs.Identity;
using AutoMapper;
using JobPortal.Domain.Entities.Identity;
using JobPortal.Application.DTOs.Job;
using JobPortal.Domain.Entities;
using JobPortal.Application.DTOs.JopApllication;

namespace JobPortal.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<RegisterDTO, AppUser>();
            CreateMap<LoginDTO, AppUser>();

            CreateMap<CreateJob, Job>();
            CreateMap<UpdateJob, Job>();
            CreateMap<Job, GetJobDTO>();

            CreateMap<CreateJobApplicationDTO, JobApplication>();
            CreateMap<UpdateJobApllicationDTO, JobApplication>();
            CreateMap<UpdateJobApplicationStatusDTO, JobApplication>();
            CreateMap<JobApplication, GetJobApplicationDTO>();
        }
    }
}
