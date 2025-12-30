using JobPortal.Application.DTOs.Job;
using JobPortal.Application.Services.Interfaces;
using JobPortal.Domain.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController(IJobServices jobServices) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await jobServices.GetAllAsync();
            return jobs is null ? NotFound() : Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var job = await jobServices.GetByIdAsync(id);
            return job is null ? NotFound() : Ok(job);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory([FromRoute] Guid categoryId)
        {
            var jobs = await jobServices.GetAllByCategoryIdAsync(categoryId);
            return jobs is null ? NotFound() : Ok(jobs);
        }

        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateJobDto job)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobServices.AddAsync(job);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateJobDto job)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobServices.UpdateAsync(id, job);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await jobServices.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
