using AutoMapper;
using JobPortal.Application.DTOs;
using JobPortal.Application.DTOs.JopApllication;
using JobPortal.Application.Services.Interfaces;
using JobPortal.Domain.Entities;
using JobPortal.Domain.Interfaces;

namespace JobPortal.Application.Services.Implementations
{
    internal class JobApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        : IJobApplicationService
    {
        public async Task<ServiceResponse> AddAsync(CreateJobApplicationDTO job)
        {
            var mappedData = mapper.Map<JobApplication>(job);
            int result = await unitOfWork.JobApplications.AddAsync(mappedData);
            if (result > 0)
                return new ServiceResponse(true, "Added");

            return new ServiceResponse(false, "Added faild");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await unitOfWork.JobApplications.DeleteAsync(id);
            if (result > 0)
                return new ServiceResponse(true, "Deleted");

            return new ServiceResponse(false, "Job application faild to be deleted");
        }

        public async Task<IEnumerable<GetJobApplicationDTO>> GetAllJobApplicationsAsync(Guid JobId)
        {
            var rawData = await unitOfWork.JobApplications.FindAsync(ja => ja.JobId == JobId);
            if (!rawData.Any())
                return [];

            return mapper.Map<IEnumerable<GetJobApplicationDTO>>(rawData);
        }

        public async Task<GetJobApplicationDTO> GetJobApplicationByUserIdAsync(
            string userId,
            Guid jobId
        )
        {
            var rawData = await unitOfWork.JobApplications.FindAsync(ja =>
                ja.UserId == userId && ja.JobId == jobId
            );

            var jobApplication = rawData.FirstOrDefault();
            return jobApplication is not null
                ? mapper.Map<GetJobApplicationDTO>(jobApplication)
                : new GetJobApplicationDTO();
        }

        public async Task<ServiceResponse> UpdateJobApplicationAsync(
            Guid applicationId,
            UpdateJobApllicationDTO job
        )
        {
            var existingApplication = await unitOfWork.JobApplications.GetByIdAsync(applicationId);
            if (existingApplication is null)
                return new ServiceResponse(false, "Job application not found");

            existingApplication.ApplicantFirstName = job.ApplicantFirstName;
            existingApplication.ApplicantLastName = job.ApplicantLastName;
            existingApplication.YearsOfExperience = job.YearsOfExperience;
            existingApplication.ResumeUrl = job.ResumeUrl;

            int result = await unitOfWork.JobApplications.UpdateAsync(existingApplication);
            return result > 0
                ? new ServiceResponse(true, "Job application updated successfully")
                : new ServiceResponse(false, "Failed to update job application");
        }

        public async Task<ServiceResponse> UpdateJobApplicationStatusAsync(
            Guid applicationId,
            UpdateJobApplicationStatusDTO job
        )
        {
            var existingApplication = await unitOfWork.JobApplications.GetByIdAsync(applicationId);
            if (existingApplication is null)
                return new ServiceResponse(false, "Job application not found");

            existingApplication.Status = job.Status;
            int result = await unitOfWork.JobApplications.UpdateAsync(existingApplication);

            return result > 0
                ? new ServiceResponse(true, "Job application status updated successfully")
                : new ServiceResponse(false, "Failed to update job application status");
        }
    }
}
