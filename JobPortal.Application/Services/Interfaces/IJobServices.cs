using JobPortal.Application.DTOs;
using JobPortal.Application.DTOs.Job;

namespace JobPortal.Application.Services.Interfaces
{
    public interface IJobServices
    {
        Task<IEnumerable<GetJobDTO>> GetAllAsync();
        Task<GetJobDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<GetJobDTO>> GetAllByCategoryIdAsync(Guid categoryId);
        Task<ServiceResponse> AddAsync(CreateJob job);
        Task<ServiceResponse> UpdateAsync(UpdateJob job);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
