using AutoMapper;
using JobPortal.Application.DTOs.Identity;
using JobPortal.Application.DTOs.Job;
using JobPortal.Application.DTOs.JopApllication;
using JobPortal.Domain.Entities;
using JobPortal.Domain.Entities.Identity;

namespace JobPortal.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<RegisterDTO, AppUser>();
            CreateMap<LoginDTO, AppUser>();

            CreateMap<CreateJobDto, Job>();
            CreateMap<UpdateJobDto, Job>();
            CreateMap<Job, GetJobDTO>();

            CreateMap<CreateJobApplicationDTO, JobApplication>();
            CreateMap<UpdateJobApllicationDTO, JobApplication>();
            CreateMap<UpdateJobApplicationStatusDTO, JobApplication>();
            CreateMap<JobApplication, GetJobApplicationDTO>();
        }
    }
}
