namespace DreamTeam.Domain.Entities;

public partial class Match
{
    public int Id { get; set; }

    public int TeamId { get; set; }

    public int PitchId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Creator { get; set; }

    public Guid Modifier { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifyDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public virtual User CreatorNavigation { get; set; } = null!;

    public virtual ICollection<MatchUser> MatchUsers { get; set; } = new List<MatchUser>();

    public virtual User ModifierNavigation { get; set; } = null!;

    public virtual Pitch Pitch { get; set; } = null!;

    public virtual ICollection<Squad> Squads { get; set; } = new List<Squad>();

    public virtual Team Team { get; set; } = null!;
}
