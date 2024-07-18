using EtiqAssessment.Application.DTOs;
using EtiqAssessment.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EtiqAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancersController : ControllerBase
    {
        private readonly IFreelancerService _freelancerService;
        private readonly ILogger<FreelancersController> _logger;

        public FreelancersController(IFreelancerService freelancerService, ILogger<FreelancersController> logger)
        {
            _freelancerService = freelancerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFreelancers()
        {
            try
            {
                var freelancers = await _freelancerService.GetFreelancersAsync();
                return Ok(freelancers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving freelancers.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFreelancer(int id)
        {
            try
            {
                var freelancer = await _freelancerService.GetFreelancerByIdAsync(id);
                if (freelancer == null)
                {
                    return NotFound();
                }
                return Ok(freelancer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving freelancer with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFreelancer(CreateFreelancerDto createFreelancerDto)
        {
            try
            {
                var freelancer = await _freelancerService.CreateFreelancerAsync(createFreelancerDto);
                return CreatedAtAction(nameof(GetFreelancer), new { id = freelancer.Id }, freelancer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a freelancer.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFreelancer(int id, UpdateFreelancerDto updateFreelancerDto)
        {
            if (id != updateFreelancerDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _freelancerService.UpdateFreelancerAsync(updateFreelancerDto);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating freelancer with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer(int id)
        {
            try
            {
                var result = await _freelancerService.DeleteFreelancerAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting freelancer with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
