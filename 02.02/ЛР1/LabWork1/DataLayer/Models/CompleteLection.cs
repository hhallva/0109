using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class CompleteLection
{
    public int UserId { get; set; }

    public int LectionId { get; set; }

    public bool IsCompleted { get; set; }

    public virtual Course Lection { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
