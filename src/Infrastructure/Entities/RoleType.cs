using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class RoleType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
