using System;
using System.Collections.Generic;

namespace order_api.Models;

public class CreateOrderRequest
{
    public string ProjectNumber { get; set; }
    public string? PrintingFor { get; set; }
    public DateTime? DateSubmitted { get; set; }
    public DateTime? DateRequired { get; set; }
    public string? SpecialInstructions { get; set; }
    public string? OrderType { get; set; }
    public string? OrderLink { get; set; }
    public string? SubmittedBy { get; set; }
    public bool? OrderComplete { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public DateTime? VisionExportDate { get; set; }
    public string? NotifyEmployee { get; set; }
    public string? NotifyEmployee2 { get; set; }

    public List<CreateOrderDetailRequest>OrderDetails { get; set; } = null!;
    public CreateOrderSignAndSealRequest? OrderSignAndSeal { get; set; }
}

public class CreateOrderDetailRequest
{
    public int Index { get; set; }
    public string Name { get; set; }
    public int? Quantity { get; set; }
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

public class CreateOrderSignAndSealRequest
{
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
