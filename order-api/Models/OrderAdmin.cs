using System;
using System.Collections.Generic;

namespace order_api.Models;

public partial class OrderAdmin
{
    public int PrimaryKey { get; set; }

    public string DomainUserName { get; set; } = null!;
}
