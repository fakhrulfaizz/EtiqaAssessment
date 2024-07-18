using System;
using System.ComponentModel.DataAnnotations;

namespace EtiqAssessment.Domain.Entities
{
    public partial class Freelancer
    {
        public int Id { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Mail { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Skillsets { get; set; }

        public string? Hobby { get; set; }
    }
}

