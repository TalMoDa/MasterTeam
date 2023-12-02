using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class Pitch
{
    public int Id { get; set; }

    public int FieldId { get; set; }

    public string Name { get; set; } = null!;

    public int SportTypeId { get; set; }

    public int MaxPlayers { get; set; }

    public int PitchTypeId { get; set; }

    public virtual Field Field { get; set; } = null!;

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual PitchType PitchType { get; set; } = null!;

    public virtual SportType SportType { get; set; } = null!;
}
