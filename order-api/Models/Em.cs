using System;
using System.Collections.Generic;

namespace order_api.Models;

public partial class Em
{
    public string Employee { get; set; } = null!;

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Org { get; set; }

    public string? HomePhone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ModUser { get; set; }

    public DateTime? ModDate { get; set; }

    public string? Status { get; set; }
}
