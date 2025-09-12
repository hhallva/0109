using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Test
{
    public int Id { get; set; }

    public int LectionId { get; set; }

    public string Name { get; set; } = null!;

    public int MinScore { get; set; }

    public virtual Lection Lection { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
