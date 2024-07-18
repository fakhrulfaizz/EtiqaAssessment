using System.ComponentModel.DataAnnotations;
using EtiqAssessment.Application.DTOs;

namespace EtiqAssessment.Application.DTOs
{
    public class FreelancerDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Skillsets { get; set; }
        public string? Hobby { get; set; }
    }
}
