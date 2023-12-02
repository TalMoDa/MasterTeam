using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class Field
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Address { get; set; }

    public string? ZipCode { get; set; }

    public bool IsActive { get; set; }

    public Guid ManagerId { get; set; }

    public virtual User Manager { get; set; } = null!;

    public virtual ICollection<Pitch> Pitches { get; set; } = new List<Pitch>();
}
