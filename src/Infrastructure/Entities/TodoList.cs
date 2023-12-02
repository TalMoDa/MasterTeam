using System;
using System.Collections.Generic;

namespace DreamTeam.Infrastructure.Entities;

public partial class TodoList
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ColourCode { get; set; } = null!;

    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
