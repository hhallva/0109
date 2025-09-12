using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Lection
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
