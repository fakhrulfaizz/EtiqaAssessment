using System;
using System.Collections.Generic;

namespace EtiqAssessment.model;

public partial class Freelancers
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Skillsets { get; set; }

    public string? Hobby { get; set; }
}
