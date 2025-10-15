using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DePickupPoint
{
    public int Id { get; set; }

    public int? PlaceIndex { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int Number { get; set; }

    public virtual ICollection<DeOrder> DeOrders { get; set; } = new List<DeOrder>();
}
