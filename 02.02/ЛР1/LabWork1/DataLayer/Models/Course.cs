using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Descrtiption { get; set; } = null!;

    public virtual ICollection<CompleteLection> CompleteLections { get; set; } = new List<CompleteLection>();

    public virtual ICollection<Lection> Lections { get; set; } = new List<Lection>();
}
