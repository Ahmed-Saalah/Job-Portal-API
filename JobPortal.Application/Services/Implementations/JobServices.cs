using AutoMapper;
using JobPortal.Application.DTOs;
using JobPortal.Application.DTOs.Job;
using JobPortal.Application.Services.Interfaces;
using JobPortal.Domain.Entities;
using JobPortal.Domain.Interfaces;

namespace JobPortal.Application.Services.Implementations
{
    public class JobServices(IUnitOfWork unitOfWork, IMapper mapper) : IJobServices
    {
        public async Task<ServiceResponse> AddAsync(CreateJobDto job)
        {
            var mappedData = mapper.Map<Job>(job);
            int result = await unitOfWork.Jobs.AddAsync(mappedData);
            if (result > 0)
                return new ServiceResponse(true, "Job Added");

            return new ServiceResponse(false, "Added faild");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await unitOfWork.Jobs.DeleteAsync(id);
            if (result > 0)
                return new ServiceResponse(true, "Deleted");

            return new ServiceResponse(false, "Job faild to be deleted");
        }

        public async Task<IEnumerable<GetJobDTO>> GetAllAsync()
        {
            var rawData = await unitOfWork.Jobs.GetAllAsync();
            if (!rawData.Any())
                return [];

            return mapper.Map<IEnumerable<GetJobDTO>>(rawData);
        }

        public async Task<IEnumerable<GetJobDTO>> GetAllByCategoryIdAsync(Guid categoryId)
        {
            var rawData = await unitOfWork.Jobs.FindAsync(j => j.CategoryId == categoryId);
            if (!rawData.Any())
                return [];

            return mapper.Map<IEnumerable<GetJobDTO>>(rawData);
        }

        public async Task<GetJobDTO> GetByIdAsync(Guid id)
        {
            var rawData = await unitOfWork.Jobs.GetByIdAsync(id);
            if (rawData == null)
                return new GetJobDTO();

            return mapper.Map<GetJobDTO>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(Guid jobId, UpdateJobDto job)
        {
            var mappedData = mapper.Map<Job>(job);
            int result = await unitOfWork.Jobs.UpdateAsync(mappedData);

            if (result > 0)
                return new ServiceResponse(true, "Job updated");

            return new ServiceResponse(false, "faild to update");
        }
    }
}
