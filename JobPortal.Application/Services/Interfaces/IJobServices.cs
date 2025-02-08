using JobPortal.Application.DTOs;
using JobPortal.Application.DTOs.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services.Interfaces
{
    public interface IJobServices
    {
        Task<IEnumerable<GetJobDTO>> GetAllAsync();
        Task<GetJobDTO> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateJob job);
        Task<ServiceResponse> UpdateAsync(UpdateJob job);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
