using System.Collections.Generic;
using System.Threading.Tasks;
using EtiqAssessment.Application.DTOs;

namespace EtiqAssessment.Application.Interfaces
{
    public interface IFreelancerService
    {
        Task<IEnumerable<FreelancerDto>> GetFreelancersAsync();
        Task<FreelancerDto> GetFreelancerByIdAsync(int id);
        Task<FreelancerDto> CreateFreelancerAsync(CreateFreelancerDto createFreelancerDto);
        Task<bool> UpdateFreelancerAsync(UpdateFreelancerDto updateFreelancerDto);
        Task<bool> DeleteFreelancerAsync(int id);
    }
}
