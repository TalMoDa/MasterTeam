using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class Squad
{
    public int Id { get; set; }

    public int MatchId { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
