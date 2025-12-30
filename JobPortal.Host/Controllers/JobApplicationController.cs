using JobPortal.Application.DTOs.JopApllication;
using JobPortal.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController(IJobApplicationService jobApplicationService)
        : ControllerBase
    {
        [Authorize(Roles = "Recruiter")]
        [HttpGet("jobs/{jobId}")]
        public async Task<IActionResult> GetAllJobApplications(Guid jobId)
        {
            var jobApplications = await jobApplicationService.GetAllJobApplicationsAsync(jobId);

            if (!jobApplications.Any())
                return NotFound("No job applications found for the given job ID.");

            return Ok(jobApplications);
        }

        [HttpGet("jobs/{jobId}/users/{userId}")]
        public async Task<IActionResult> GetJobApplicationByUserId(string userId, Guid jobId)
        {
            var userApplication = await jobApplicationService.GetJobApplicationByUserIdAsync(
                userId,
                jobId
            );
            if (userApplication == null)
            {
                return NotFound("No job applications found for the given user ID andjob ID.");
            }

            return Ok(userApplication);
        }

        [HttpPost("jobs")]
        public async Task<IActionResult> Add([FromBody] CreateJobApplicationDTO jobApplication)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.AddAsync(jobApplication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "JobSeeker")]
        [HttpPut("jobs/applications/{applicationId}")]
        public async Task<IActionResult> UpdateJobApplication(
            [FromRoute] Guid applicationId,
            [FromBody] UpdateJobApllicationDTO jobApplication
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.UpdateJobApplicationAsync(
                applicationId,
                jobApplication
            );
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPut("jobs/applications/{applicationId}/status")]
        public async Task<IActionResult> UpdateJobApplicationStatus(
            [FromRoute] Guid applicationId,
            [FromBody] UpdateJobApplicationStatusDTO jobApplication
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.UpdateJobApplicationStatusAsync(
                applicationId,
                jobApplication
            );
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("jobs/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await jobApplicationService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
