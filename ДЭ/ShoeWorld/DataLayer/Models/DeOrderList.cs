using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DeOrderList
{
    public int OrderId { get; set; }

    public string ProductId { get; set; } = null!;

    public int Amount { get; set; }

    public virtual DeOrder Order { get; set; } = null!;

    public virtual DeProduct Product { get; set; } = null!;
}
