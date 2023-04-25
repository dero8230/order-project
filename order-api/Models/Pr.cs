using System;
using System.Collections.Generic;

namespace order_api.Models;

public partial class Pr
{
    public string Wbs1 { get; set; } = null!;

    public string Wbs2 { get; set; } = null!;

    public string Wbs3 { get; set; } = null!;

    public string? Name { get; set; }

    public string? ChargeType { get; set; }

    public string SubLevel { get; set; } = null!;

    public string? Principal { get; set; }

    public string? ProjMgr { get; set; }

    public string? Supervisor { get; set; }

    public string? ClientId { get; set; }

    public string? Claddress { get; set; }

    public decimal Fee { get; set; }

    public decimal ReimbAllow { get; set; }

    public decimal ConsultFee { get; set; }

    public decimal BudOhrate { get; set; }

    public string? Status { get; set; }

    public string? RevType { get; set; }

    public decimal MultAmt { get; set; }

    public string? Org { get; set; }

    public string? UnitTable { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal PctComp { get; set; }

    public decimal LabPctComp { get; set; }

    public decimal ExpPctComp { get; set; }

    public string BillByDefault { get; set; } = null!;

    public string BillableWarning { get; set; } = null!;

    public string? Memo { get; set; }

    public string BudgetedFlag { get; set; } = null!;

    public string? BudgetedLevels { get; set; }

    public string? BillWbs1 { get; set; }

    public string? BillWbs2 { get; set; }

    public string? BillWbs3 { get; set; }

    public string Xcharge { get; set; } = null!;

    public short XchargeMethod { get; set; }

    public decimal XchargeMult { get; set; }

    public string? Description { get; set; }

    public int Closed { get; set; }

    public int ReadOnly { get; set; }

    public int DefaultEffortDriven { get; set; }

    public int DefaultTaskType { get; set; }

    public int VersionId { get; set; }

    public string? ContactId { get; set; }

    public string? ClbillingAddr { get; set; }

    public string? LongName { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? County { get; set; }

    public string? Country { get; set; }

    public string FederalInd { get; set; } = null!;

    public string? ProjectType { get; set; }

    public string? Responsibility { get; set; }

    public string Referable { get; set; } = null!;

    public DateTime? EstCompletionDate { get; set; }

    public DateTime? ActCompletionDate { get; set; }

    public DateTime? ContractDate { get; set; }

    public DateTime? BidDate { get; set; }

    public string? ComplDateComment { get; set; }

    public decimal FirmCost { get; set; }

    public string? FirmCostComment { get; set; }

    public decimal TotalProjectCost { get; set; }

    public string? TotalCostComment { get; set; }

    public string? OpportunityId { get; set; }

    public string? ClientConfidential { get; set; }

    public string? ClientAlias { get; set; }

    public string AvailableForCrm { get; set; } = null!;

    public string ReadyForApproval { get; set; } = null!;

    public string ReadyForProcessing { get; set; } = null!;

    public string? BillingClientId { get; set; }

    public string? BillingContactId { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? ProposalWbs1 { get; set; }

    public short CostRateMeth { get; set; }

    public int CostRateTableNo { get; set; }

    public short PayRateMeth { get; set; }

    public int PayRateTableNo { get; set; }

    public string? Locale { get; set; }

    public string LineItemApproval { get; set; } = null!;

    public string LineItemApprovalEk { get; set; } = null!;

    public string? BudgetSource { get; set; }

    public string? BudgetLevel { get; set; }

    public DateTime? ProfServicesComplDate { get; set; }

    public DateTime? ConstComplDate { get; set; }

    public string? ProjectCurrencyCode { get; set; }

    public decimal ProjectExchangeRate { get; set; }

    public string? BillingCurrencyCode { get; set; }

    public decimal BillingExchangeRate { get; set; }

    public string RestrictChargeCompanies { get; set; } = null!;

    public decimal FeeBillingCurrency { get; set; }

    public decimal ReimbAllowBillingCurrency { get; set; }

    public decimal ConsultFeeBillingCurrency { get; set; }

    public string RevUpsetLimits { get; set; } = null!;

    public string? RevUpsetWbs2 { get; set; }

    public string? RevUpsetWbs3 { get; set; }

    public string RevUpsetIncludeComp { get; set; } = null!;

    public string RevUpsetIncludeCons { get; set; } = null!;

    public string RevUpsetIncludeReimb { get; set; } = null!;

    public decimal Pormbrate { get; set; }

    public decimal Pocnsrate { get; set; }

    public string? PlanId { get; set; }

    public string TkcheckRpdate { get; set; } = null!;

    public string IcbillingLab { get; set; } = null!;

    public short IcbillingLabMethod { get; set; }

    public decimal IcbillingLabMult { get; set; }

    public string IcbillingExp { get; set; } = null!;

    public short IcbillingExpMethod { get; set; }

    public decimal IcbillingExpMult { get; set; }

    public string RequireComments { get; set; } = null!;

    public string TkcheckRpplannedHrs { get; set; } = null!;

    public string BillByDefaultConsultants { get; set; } = null!;

    public string BillByDefaultOtherExp { get; set; } = null!;

    public int BillByDefaultOrtable { get; set; }

    public string? PhoneFormat { get; set; }

    public string? FaxFormat { get; set; }

    public string RevType2 { get; set; } = null!;

    public string RevType3 { get; set; } = null!;

    public string RevType4 { get; set; } = null!;

    public string RevType5 { get; set; } = null!;

    public short RevUpsetCategoryToAdjust { get; set; }

    public string? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ModUser { get; set; }

    public DateTime? ModDate { get; set; }

    public decimal FeeFunctionalCurrency { get; set; }

    public decimal ReimbAllowFunctionalCurrency { get; set; }

    public decimal ConsultFeeFunctionalCurrency { get; set; }

    public string RevenueMethod { get; set; } = null!;

    public int IcbillingLabTableNo { get; set; }

    public int IcbillingExpTableNo { get; set; }

    public string? Biller { get; set; }

    public decimal FeeDirLab { get; set; }

    public decimal FeeDirExp { get; set; }

    public decimal ReimbAllowExp { get; set; }

    public decimal ReimbAllowCons { get; set; }

    public decimal FeeDirLabBillingCurrency { get; set; }

    public decimal FeeDirExpBillingCurrency { get; set; }

    public decimal ReimbAllowExpBillingCurrency { get; set; }

    public decimal ReimbAllowConsBillingCurrency { get; set; }

    public decimal FeeDirLabFunctionalCurrency { get; set; }

    public decimal FeeDirExpFunctionalCurrency { get; set; }

    public decimal ReimbAllowExpFunctionalCurrency { get; set; }

    public decimal ReimbAllowConsFunctionalCurrency { get; set; }

    public string RevUpsetIncludeCompDirExp { get; set; } = null!;

    public string RevUpsetIncludeReimbCons { get; set; } = null!;

    public string? AwardType { get; set; }

    public string? Duration { get; set; }

    public string? ContractTypeGovCon { get; set; }

    public string? CompetitionType { get; set; }

    public string? MasterContract { get; set; }

    public string? Solicitation { get; set; }

    public string? Naics { get; set; }

    public string? OurRole { get; set; }

    public string AjeraSync { get; set; } = null!;

    public string? ServProCode { get; set; }

    public decimal FesurchargePct { get; set; }

    public decimal Fesurcharge { get; set; }

    public decimal FeaddlExpensesPct { get; set; }

    public decimal FeaddlExpenses { get; set; }

    public decimal FeotherPct { get; set; }

    public decimal Feother { get; set; }

    public string? ProjectTemplate { get; set; }

    public decimal AjeraSpentLabor { get; set; }

    public decimal AjeraSpentReimbursable { get; set; }

    public decimal AjeraSpentConsultant { get; set; }

    public decimal AjeraCostLabor { get; set; }

    public decimal AjeraCostReimbursable { get; set; }

    public decimal AjeraCostConsultant { get; set; }

    public decimal AjeraWiplabor { get; set; }

    public decimal AjeraWipreimbursable { get; set; }

    public decimal AjeraWipconsultant { get; set; }

    public decimal AjeraBilledLabor { get; set; }

    public decimal AjeraBilledReimbursable { get; set; }

    public decimal AjeraBilledConsultant { get; set; }

    public decimal AjeraReceivedLabor { get; set; }

    public decimal AjeraReceivedReimbursable { get; set; }

    public decimal AjeraReceivedConsultant { get; set; }

    public string? TlinternalKey { get; set; }

    public string? TlprojectId { get; set; }

    public string? TlprojectName { get; set; }

    public string? TlchargeBandInternalKey { get; set; }

    public string? TlchargeBandExternalCode { get; set; }

    public DateTime? TlsyncModDate { get; set; }

    public string? Pimid { get; set; }
}
