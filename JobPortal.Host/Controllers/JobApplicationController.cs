using JobPortal.Application.DTOs.JopApllication;
using JobPortal.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController(IJobApplicationService jobApplicationService) : ControllerBase
    {
        [Authorize(Roles = "Recruiter")]
        [HttpGet("job/{id}")]
        public async Task<IActionResult> GetAllJobApplications(Guid id)
        {
            var jobApplications = await jobApplicationService.GetAllJobApplicationsAsync(id);
            
            if (!jobApplications.Any())
                return NotFound("No job applications found for the given job ID.");
            
            return Ok(jobApplications);
        } 


        [HttpGet("user/{userId}/job/{jobId}")]
        public async Task<IActionResult> GetJobApplicationByUserId(string userId, Guid jobId)
        {
            var userApplication = await jobApplicationService.GetJobApplicationByUserIdAsync(userId, jobId);
            if (userApplication == null)
            {
                return NotFound("No job applications found for the given user ID andjob ID.");
            }

            return Ok(userApplication);
        } 

        [HttpPost("add-job-application")]
        public async Task<IActionResult> Add([FromBody] CreateJobApplicationDTO jobApplication)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.AddAsync(jobApplication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "JobSeeker")]
        [HttpPut("update-job-application")]
        public async Task<IActionResult> UpdateJobApplication([FromBody] UpdateJobApllicationDTO jobApplication)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.UpdateJobApplicationAsync(jobApplication);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        
        [Authorize(Roles = "Recruiter")]
        [HttpPut("update-status-by-recruiter")]
        public async Task<IActionResult> UpdateJobApplicationStatus([FromBody] UpdateJobApplicationStatusDTO jobApplication)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.UpdateJobApplicationStatusAsync(jobApplication);
            return result.Success ? Ok(result) : BadRequest(result);
        }
       

        [HttpDelete("delete-job-application/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await jobApplicationService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
