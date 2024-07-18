using EtiqAssessment.Domain.Entities;
using EtiqAssessment.Domain.Interfaces;
using EtiqAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtiqAssessment.Infrastructure.Repositories
{
    public class FreelancerRepository : IFreelancerRepository
    {
        private readonly EtiqAssessmentDbContext _context;

        public FreelancerRepository(EtiqAssessmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Freelancer>> GetFreelancersAsync()
        {
            return await _context.Freelancers.ToListAsync();
        }

        public async Task<Freelancer> GetFreelancerByIdAsync(int id)
        {
            return await _context.Freelancers.FindAsync(id);
        }

        public async Task<Freelancer> CreateFreelancerAsync(Freelancer freelancer)
        {
            _context.Freelancers.Add(freelancer);
            await _context.SaveChangesAsync();
            return freelancer;
        }

        public async Task UpdateFreelancerAsync(Freelancer freelancer)
        {
            _context.Entry(freelancer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFreelancerAsync(Freelancer freelancer)
        {
            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();
        }
    }
}
