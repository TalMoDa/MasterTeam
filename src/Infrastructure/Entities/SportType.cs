using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class SportType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Pitch> Pitches { get; set; } = new List<Pitch>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
