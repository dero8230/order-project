using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace order_api.Models;

public partial class OrderSignAndSeal
{
    public string OrderId { get; set; } = null!;

    [Key]
    public int Ssid { get; set; }

    public bool? Electronic { get; set; }

    public string? ArchSignee { get; set; }

    public DateTime? ArchCompletedDate { get; set; }

    public string? MechSignee { get; set; }

    public DateTime? MechCompletedDate { get; set; }

    public string? ElectSignee { get; set; }

    public DateTime? ElectCompletedDate { get; set; }

    public string? PlumbSignee { get; set; }

    public DateTime? PlumbCompletedDate { get; set; }

    public string? CivilSignee { get; set; }

    public DateTime? CivilCompletedDate { get; set; }

    public string? StructSignee { get; set; }

    public DateTime? StructCompletedDate { get; set; }

    public string? LeadPermit { get; set; }

    public DateTime? LeadPermitCompletedDate { get; set; }

    public bool? Completed { get; set; }

    public DateTime? DateCompleted { get; set; }

    public string? State { get; set; }

    public string? Notes { get; set; }

    public string? ArchSigner { get; set; }

    public string? MechSigner { get; set; }

    public string? ElectSigner { get; set; }

    public string? PlumbSigner { get; set; }

    public string? CivilSigner { get; set; }

    public string? StructSigner { get; set; }
}
