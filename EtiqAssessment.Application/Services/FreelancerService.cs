using EtiqAssessment.Application.DTOs;
using EtiqAssessment.Application.Interfaces;
using EtiqAssessment.Domain.Entities;
using EtiqAssessment.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtiqAssessment.Application.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly ILogger<FreelancerService> _logger;

        public FreelancerService(IFreelancerRepository freelancerRepository, ILogger<FreelancerService> logger)
        {
            _freelancerRepository = freelancerRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<FreelancerDto>> GetFreelancersAsync()
        {
            try
            {
                var freelancers = await _freelancerRepository.GetFreelancersAsync();
                return freelancers.Select(f => new FreelancerDto
                {
                    Id = f.Id,
                    Username = f.Username,
                    Mail = f.Mail,
                    PhoneNumber = f.PhoneNumber,
                    Skillsets = f.Skillsets,
                    Hobby = f.Hobby
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving freelancers.");
                throw;
            }
        }

        public async Task<FreelancerDto> GetFreelancerByIdAsync(int id)
        {
            try
            {
                var freelancer = await _freelancerRepository.GetFreelancerByIdAsync(id);
                if (freelancer == null) return null;

                return new FreelancerDto
                {
                    Id = freelancer.Id,
                    Username = freelancer.Username,
                    Mail = freelancer.Mail,
                    PhoneNumber = freelancer.PhoneNumber,
                    Skillsets = freelancer.Skillsets,
                    Hobby = freelancer.Hobby
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving freelancer with ID {id}.");
                throw;
            }
        }

        public async Task<FreelancerDto> CreateFreelancerAsync(CreateFreelancerDto createFreelancerDto)
        {
            try
            {
                var freelancer = new Freelancer
                {
                    Username = createFreelancerDto.Username,
                    Mail = createFreelancerDto.Mail,
                    PhoneNumber = createFreelancerDto.PhoneNumber,
                    Skillsets = createFreelancerDto.Skillsets,
                    Hobby = createFreelancerDto.Hobby
                };

                freelancer = await _freelancerRepository.CreateFreelancerAsync(freelancer);
                return new FreelancerDto
                {
                    Id = freelancer.Id,
                    Username = freelancer.Username,
                    Mail = freelancer.Mail,
                    PhoneNumber = freelancer.PhoneNumber,
                    Skillsets = freelancer.Skillsets,
                    Hobby = freelancer.Hobby
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a freelancer.");
                throw;
            }
        }

        public async Task<bool> UpdateFreelancerAsync(UpdateFreelancerDto updateFreelancerDto)
        {
            try
            {
                var freelancer = await _freelancerRepository.GetFreelancerByIdAsync(updateFreelancerDto.Id);
                if (freelancer == null) return false;

                freelancer.Username = updateFreelancerDto.Username;
                freelancer.Mail = updateFreelancerDto.Mail;
                freelancer.PhoneNumber = updateFreelancerDto.PhoneNumber;
                freelancer.Skillsets = updateFreelancerDto.Skillsets;
                freelancer.Hobby = updateFreelancerDto.Hobby;

                await _freelancerRepository.UpdateFreelancerAsync(freelancer);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating freelancer with ID {updateFreelancerDto.Id}.");
                throw;
            }
        }

        public async Task<bool> DeleteFreelancerAsync(int id)
        {
            try
            {
                var freelancer = await _freelancerRepository.GetFreelancerByIdAsync(id);
                if (freelancer == null) return false;

                await _freelancerRepository.DeleteFreelancerAsync(freelancer);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting freelancer with ID {id}.");
                throw;
            }
        }
    }
}
