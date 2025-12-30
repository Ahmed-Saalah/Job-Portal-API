using JobPortal.Application.DTOs.JopApllication;
using JobPortal.Application.Services.Interfaces;
using JobPortal.Domain.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController(IJobApplicationService jobApplicationService)
        : ControllerBase
    {
        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpGet("job/{jobId:guid}")]
        public async Task<IActionResult> GetAllJobApplications(Guid jobId)
        {
            var jobApplications = await jobApplicationService.GetAllJobApplicationsAsync(jobId);

            if (!jobApplications.Any())
                return NotFound("No job applications found for the given job ID.");

            return Ok(jobApplications);
        }

        [HttpGet("user/{userId}/job/{jobId:guid}")]
        public async Task<IActionResult> GetJobApplicationByUserId(string userId, Guid jobId)
        {
            var userApplication = await jobApplicationService.GetJobApplicationByUserIdAsync(
                userId,
                jobId
            );
            if (userApplication == null)
            {
                return NotFound("Application not found.");
            }

            return Ok(userApplication);
        }

        [Authorize(Roles = UserRolesConstants.JobSeeker)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobApplicationDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.AddAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = UserRolesConstants.JobSeeker)]
        [HttpPut()]
        public async Task<IActionResult> Update(
            [FromRoute] Guid applicationId,
            [FromBody] UpdateJobApllicationDTO dto
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.UpdateJobApplicationAsync(applicationId, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = UserRolesConstants.Recruiter)]
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(
            [FromRoute] Guid applicationId,
            [FromBody] UpdateJobApplicationStatusDTO dto
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await jobApplicationService.UpdateJobApplicationStatusAsync(
                applicationId,
                dto
            );
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = UserRolesConstants.JobSeeker)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await jobApplicationService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
