using System;
using System.Collections.Generic;

namespace order_api.Models;

public partial class CfgorgCode
{
    public string Code { get; set; } = null!;

    public short OrgLevel { get; set; }

    public string UicultureName { get; set; } = null!;

    public string Label { get; set; } = null!;
}
