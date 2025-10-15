using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DeProduct
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int SupplierId { get; set; }

    public int ManufacturerId { get; set; }

    public bool GenderType { get; set; }

    public int Discount { get; set; }

    public int Amount { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public virtual ICollection<DeOrderList> DeOrderLists { get; set; } = new List<DeOrderList>();

    public virtual DeManufacturer Manufacturer { get; set; } = null!;

    public virtual DeSupplier Supplier { get; set; } = null!;
}
