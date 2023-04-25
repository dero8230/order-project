﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace order_api.Models;

public partial class OrderDetail
{
    [Key]
    public int DetailsId { get; set; }

    public string OrderId { get; set; } = null!;

    public string? PricingId { get; set; }

    public int Index { get; set; }

    public string Name { get; set; } = null!;

    public string? Quantity { get; set; }

    public bool? BindInSet { get; set; }

    public string? Description { get; set; }

    public int? Pages { get; set; }

    public bool? Completed { get; set; }

    public DateTime? DateCompleted { get; set; }

    public string? CompletedBy { get; set; }

    public string? Notes { get; set; }

    public bool? FileStaged { get; set; }

    public bool? FileArchived { get; set; }

    public bool? FileQc { get; set; }
}
