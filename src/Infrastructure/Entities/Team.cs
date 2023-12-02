using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class Team
{
    public int Id { get; set; }

    public int SportTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Creator { get; set; }

    public Guid Modifier { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifyDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual User CreatorNavigation { get; set; } = null!;

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual User ModifierNavigation { get; set; } = null!;

    public virtual SportType SportType { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
