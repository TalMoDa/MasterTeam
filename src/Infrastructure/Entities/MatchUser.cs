using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class MatchUser
{
    public int MatchId { get; set; }

    public Guid UserId { get; set; }

    public virtual Match Match { get; set; } = null!;
}
