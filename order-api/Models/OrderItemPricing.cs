using System;
using System.Collections.Generic;

namespace order_api.Models;

public partial class OrderItemPricing
{
    public Guid? PricingId { get; set; }

    public string Item { get; set; } = null!;

    public bool? Color { get; set; }

    public string Size { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Cost { get; set; } = null!;

    public int ReferenceNumber { get; set; }

    public string MasterDescription { get; set; } = null!;

    public string AccountCode { get; set; } = null!;

    public bool? Active { get; set; }

    public bool? HasFile { get; set; }
}
