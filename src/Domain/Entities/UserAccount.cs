namespace DreamTeam.Domain.Entities;

public partial class UserAccount
{
    public Guid Id { get; set; }

    public byte[] Salt { get; set; } = null!;

    public byte[] HashedPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsVerified { get; set; }

    public virtual User? User { get; set; }
}
