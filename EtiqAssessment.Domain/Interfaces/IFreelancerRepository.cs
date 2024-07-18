using System.Collections.Generic;
using System.Threading.Tasks;
using EtiqAssessment.Domain.Entities;

namespace EtiqAssessment.Domain.Interfaces
{
    public interface IFreelancerRepository
    {
        Task<IEnumerable<Freelancer>> GetFreelancersAsync();
        Task<Freelancer> GetFreelancerByIdAsync(int id);
        Task<Freelancer> CreateFreelancerAsync(Freelancer freelancer);
        Task UpdateFreelancerAsync(Freelancer freelancer);
        Task DeleteFreelancerAsync(Freelancer freelancer);
    }
}
