using System;
using System.Collections.Generic;

namespace order_api.Models;

public partial class OrderSignee
{
    public string DisplayName { get; set; } = null!;

    public string Discipline { get; set; } = null!;

    public string? Email { get; set; }
}
