using System.ComponentModel.DataAnnotations;

namespace EtiqAssessment.Application.DTOs
{
    public class CreateFreelancerDto
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Mail { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Skillsets { get; set; }
        public string? Hobby { get; set; }
    }
}