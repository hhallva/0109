using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DeSupplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DeProduct> DeProducts { get; set; } = new List<DeProduct>();
}
