namespace DreamTeam.Domain.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public Guid UserAccountId { get; set; }

    public int RoleId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Creator { get; set; }

    public Guid Modifier { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifyDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<Field> Fields { get; set; } = new List<Field>();

    public virtual ICollection<Match> MatchCreatorNavigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchModifierNavigations { get; set; } = new List<Match>();

    public virtual RoleType Role { get; set; } = null!;

    public virtual ICollection<Team> TeamCreatorNavigations { get; set; } = new List<Team>();

    public virtual ICollection<Team> TeamModifierNavigations { get; set; } = new List<Team>();

    public virtual UserAccount UserAccount { get; set; } = null!;

    public virtual ICollection<UserRanking> UserRankings { get; set; } = new List<UserRanking>();

    public virtual ICollection<Squad> Squads { get; set; } = new List<Squad>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
