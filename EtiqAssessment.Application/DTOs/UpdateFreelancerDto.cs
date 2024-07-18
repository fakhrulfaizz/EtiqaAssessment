using System.ComponentModel.DataAnnotations;

namespace EtiqAssessment.Application.DTOs
{
    public class UpdateFreelancerDto : CreateFreelancerDto
    {
        [Required]
        public int Id { get; set; }
    }
}
