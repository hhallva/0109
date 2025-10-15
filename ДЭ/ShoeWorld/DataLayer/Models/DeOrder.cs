using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DeOrder
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int PickupPointId { get; set; }

    public int UserId { get; set; }

    public int PickupCode { get; set; }

    public bool IsComplete { get; set; }

    public virtual ICollection<DeOrderList> DeOrderLists { get; set; } = new List<DeOrderList>();

    public virtual DePickupPoint PickupPoint { get; set; } = null!;

    public virtual DeUser User { get; set; } = null!;
}
