using JobPortal.Application.DTOs.Job;
using JobPortal.Application.Services.Interfaces;
using JobPortal.Domain.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController(IJobServices jobServices) : ControllerBase
    {
        [HttpGet("jobs")]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await jobServices.GetAllAsync();
            if (jobs == null)
            {
                return NotFound(jobs);
            }
            return Ok(jobs);
        }

        [HttpGet("jobs/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var job = await jobServices.GetByIdAsync(id);
            if (job == null)
                return NotFound(job);

            return Ok(job);
        }

        [HttpGet("jobs/categories/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory([FromRoute] Guid categoryId)
        {
            var jobs = await jobServices.GetAllByCategoryIdAsync(categoryId);
            if (jobs == null)
            {
                return NotFound(jobs);
            }
            return Ok(jobs);
        }

        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpPost("jobs")]
        public async Task<IActionResult> Add([FromBody] CreateJobDto job)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobServices.AddAsync(job);
            return result.Success ? Ok(result) : BadRequest(ModelState);
        }

        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpPut("jobs/{jobId}")]
        public async Task<IActionResult> Update([FromRoute] Guid jobId, [FromBody] UpdateJobDto job)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobServices.UpdateAsync(jobId, job);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await jobServices.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
