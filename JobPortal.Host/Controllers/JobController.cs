using JobPortal.Application.DTOs.Job;
using JobPortal.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController(IJobServices jobServices) : ControllerBase
    {
        [HttpGet("get-all-jobs")]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await jobServices.GetAllAsync();
            if (jobs == null)
            {
                return NotFound(jobs);
            }
            return Ok(jobs);
        }

        [HttpGet("get-job")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var job = await jobServices.GetByIdAsync(id);
            if (job == null) 
                return NotFound(job);

            return Ok(job);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory(Guid categoryId)
        {
            var jobs = await jobServices.GetAllByCategoryIdAsync(categoryId);
            if (jobs == null)
            {
                return NotFound(jobs);
            }
            return Ok(jobs);
        }
        
        [Authorize(Roles = "Recruiter")]
        [HttpPost("add-job")]
        public async Task<IActionResult> Add(CreateJob job)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobServices.AddAsync(job);   
            return result.Success ? Ok(result) : BadRequest(ModelState);
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPut("update-job")]
        public async Task<IActionResult> Update(UpdateJob job)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobServices.UpdateAsync(job);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Recruiter")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await jobServices.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
