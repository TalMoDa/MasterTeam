namespace DreamTeam.Domain.Entities;

public partial class PitchType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Pitch> Pitches { get; set; } = new List<Pitch>();
}
