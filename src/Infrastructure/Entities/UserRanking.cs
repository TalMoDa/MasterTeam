using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class UserRanking
{
    public Guid UserId { get; set; }

    public int TeamId { get; set; }

    public int NumberOfRankers { get; set; }

    public decimal RankSum { get; set; }

    public decimal RankAverage { get; set; }

    public int TotalMatches { get; set; }

    public virtual User User { get; set; } = null!;
}
