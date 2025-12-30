using JobPortal.Application.DTOs;
using JobPortal.Application.DTOs.JopApllication;

namespace JobPortal.Application.Services.Interfaces
{
    public interface IJobApplicationService
    {
        Task<IEnumerable<GetJobApplicationDTO>> GetAllJobApplicationsAsync(Guid JobId);
        Task<GetJobApplicationDTO> GetJobApplicationByUserIdAsync(string UserId, Guid jobId);
        Task<ServiceResponse> AddAsync(CreateJobApplicationDTO job);
        Task<ServiceResponse> UpdateJobApplicationAsync(
            Guid applicationId,
            UpdateJobApllicationDTO job
        );
        Task<ServiceResponse> UpdateJobApplicationStatusAsync(
            Guid applicationId,
            UpdateJobApplicationStatusDTO job
        );
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
