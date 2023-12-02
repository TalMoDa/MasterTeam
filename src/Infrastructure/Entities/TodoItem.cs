using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class TodoItem
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string Title { get; set; } = null!;

    public string? Note { get; set; }

    public int Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public bool Done { get; set; }

    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual TodoList List { get; set; } = null!;
}
