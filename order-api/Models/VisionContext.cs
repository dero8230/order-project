using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using order_api.Models.PR;

namespace order_api.Models;

public partial class VisionContext : DbContext
{
    public VisionContext()
    {
    }

    public VisionContext(DbContextOptions<VisionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CfgorgCode> CfgorgCodes { get; set; }

    public virtual DbSet<Em> Ems { get; set; }

    public virtual DbSet<Pr> Prs { get; set; }

    public DbSet<ActiveJob> ActiveJobs { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WACKBOOK\\MSSQLSERVER01;Database=Vision;Trusted_Connection=True;TrustServerCertificate=true");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActiveJobConfiguration());
        modelBuilder.Entity<CfgorgCode>(entity =>
        {
            entity.HasKey(e => new { e.Code, e.OrgLevel, e.UicultureName }).HasName("CFGOrgCodesPK");

            entity.ToTable("CFGOrgCodes");

            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UicultureName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UICultureName");
            entity.Property(e => e.Label)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Em>(entity =>
        {
            entity.HasKey(e => e.Employee)
                .HasName("EMPK")
                .IsClustered(false);

            entity.ToTable("EM");

            entity.Property(e => e.Employee)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMail");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Org)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pr>(entity =>
        {
            entity.HasKey(e => new { e.Wbs1, e.Wbs2, e.Wbs3 })
                .HasName("PRPK")
                .IsClustered(false);

            entity.ToTable("PR");

            entity.Property(e => e.Wbs1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("WBS1");
            entity.Property(e => e.Wbs2)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("WBS2");
            entity.Property(e => e.Wbs3)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("WBS3");
            entity.Property(e => e.ActCompletionDate).HasColumnType("datetime");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AjeraBilledConsultant).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraBilledLabor).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraBilledReimbursable).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraCostConsultant).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraCostLabor).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraCostReimbursable).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraReceivedConsultant).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraReceivedLabor).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraReceivedReimbursable).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraSpentConsultant).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraSpentLabor).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraSpentReimbursable).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.AjeraSync)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.AjeraWipconsultant)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("AjeraWIPConsultant");
            entity.Property(e => e.AjeraWiplabor)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("AjeraWIPLabor");
            entity.Property(e => e.AjeraWipreimbursable)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("AjeraWIPReimbursable");
            entity.Property(e => e.AvailableForCrm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("AvailableForCRM");
            entity.Property(e => e.AwardType)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.BidDate).HasColumnType("datetime");
            entity.Property(e => e.BillByDefault)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.BillByDefaultConsultants)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('E')");
            entity.Property(e => e.BillByDefaultOrtable).HasColumnName("BillByDefaultORTable");
            entity.Property(e => e.BillByDefaultOtherExp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('E')");
            entity.Property(e => e.BillWbs1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("BillWBS1");
            entity.Property(e => e.BillWbs2)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("BillWBS2");
            entity.Property(e => e.BillWbs3)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("BillWBS3");
            entity.Property(e => e.BillableWarning)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.Biller)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BillingClientId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("BillingClientID");
            entity.Property(e => e.BillingContactId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("BillingContactID");
            entity.Property(e => e.BillingCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.BillingExchangeRate).HasColumnType("decimal(19, 10)");
            entity.Property(e => e.BudOhrate)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("BudOHRate");
            entity.Property(e => e.BudgetLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BudgetSource)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BudgetedFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.BudgetedLevels)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ChargeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Claddress)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLAddress");
            entity.Property(e => e.ClbillingAddr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLBillingAddr");
            entity.Property(e => e.ClientAlias)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ClientConfidential)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ClientId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ClientID");
            entity.Property(e => e.CompetitionType)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ComplDateComment)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ConstComplDate).HasColumnType("datetime");
            entity.Property(e => e.ConsultFee).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ConsultFeeBillingCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ConsultFeeFunctionalCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ContactId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ContactID");
            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.ContractTypeGovCon)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.County)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Duration)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMail");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.EstCompletionDate).HasColumnType("datetime");
            entity.Property(e => e.ExpPctComp).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.FaxFormat)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.FeaddlExpenses)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("FEAddlExpenses");
            entity.Property(e => e.FeaddlExpensesPct)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("FEAddlExpensesPct");
            entity.Property(e => e.FederalInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.Fee).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeBillingCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeDirExp).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeDirExpBillingCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeDirExpFunctionalCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeDirLab).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeDirLabBillingCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeDirLabFunctionalCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FeeFunctionalCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Feother)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("FEOther");
            entity.Property(e => e.FeotherPct)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("FEOtherPct");
            entity.Property(e => e.Fesurcharge)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("FESurcharge");
            entity.Property(e => e.FesurchargePct)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("FESurchargePct");
            entity.Property(e => e.FirmCost).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.FirmCostComment)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IcbillingExp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('G')")
                .HasColumnName("ICBillingExp");
            entity.Property(e => e.IcbillingExpMethod).HasColumnName("ICBillingExpMethod");
            entity.Property(e => e.IcbillingExpMult)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("ICBillingExpMult");
            entity.Property(e => e.IcbillingExpTableNo).HasColumnName("ICBillingExpTableNo");
            entity.Property(e => e.IcbillingLab)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('G')")
                .HasColumnName("ICBillingLab");
            entity.Property(e => e.IcbillingLabMethod).HasColumnName("ICBillingLabMethod");
            entity.Property(e => e.IcbillingLabMult)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("ICBillingLabMult");
            entity.Property(e => e.IcbillingLabTableNo).HasColumnName("ICBillingLabTableNo");
            entity.Property(e => e.LabPctComp).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.LineItemApproval)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('S')");
            entity.Property(e => e.LineItemApprovalEk)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('S')")
                .HasColumnName("LineItemApprovalEK");
            entity.Property(e => e.Locale)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LongName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MasterContract)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Memo).IsUnicode(false);
            entity.Property(e => e.ModDate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MultAmt).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Naics)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NAICS");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.OpportunityId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("OpportunityID");
            entity.Property(e => e.Org)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OurRole)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PctComp).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.PhoneFormat)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Pimid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PIMID");
            entity.Property(e => e.PlanId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PlanID");
            entity.Property(e => e.Pocnsrate)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("POCNSRate");
            entity.Property(e => e.Pormbrate)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("PORMBRate");
            entity.Property(e => e.Principal)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProfServicesComplDate).HasColumnType("datetime");
            entity.Property(e => e.ProjMgr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProjectCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ProjectExchangeRate).HasColumnType("decimal(19, 10)");
            entity.Property(e => e.ProjectTemplate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProjectType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProposalWbs1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ProposalWBS1");
            entity.Property(e => e.ReadyForApproval)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.ReadyForProcessing)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.Referable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.ReimbAllow).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowBillingCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowCons).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowConsBillingCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowConsFunctionalCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowExp).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowExpBillingCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowExpFunctionalCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ReimbAllowFunctionalCurrency).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.RequireComments)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('C')");
            entity.Property(e => e.Responsibility)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RestrictChargeCompanies)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RevType2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevType3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevType4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevType5)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevUpsetIncludeComp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevUpsetIncludeCompDirExp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevUpsetIncludeCons)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevUpsetIncludeReimb)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevUpsetIncludeReimbCons)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevUpsetLimits)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.RevUpsetWbs2)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("RevUpsetWBS2");
            entity.Property(e => e.RevUpsetWbs3)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("RevUpsetWBS3");
            entity.Property(e => e.RevenueMethod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('U')");
            entity.Property(e => e.ServProCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Solicitation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SubLevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");
            entity.Property(e => e.Supervisor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TkcheckRpdate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("TKCheckRPDate");
            entity.Property(e => e.TkcheckRpplannedHrs)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("TKCheckRPPlannedHrs");
            entity.Property(e => e.TlchargeBandExternalCode)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("TLChargeBandExternalCode");
            entity.Property(e => e.TlchargeBandInternalKey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TLChargeBandInternalKey");
            entity.Property(e => e.TlinternalKey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TLInternalKey");
            entity.Property(e => e.TlprojectId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TLProjectID");
            entity.Property(e => e.TlprojectName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TLProjectName");
            entity.Property(e => e.TlsyncModDate)
                .HasColumnType("datetime")
                .HasColumnName("TLSyncModDate");
            entity.Property(e => e.TotalCostComment)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalProjectCost).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.UnitTable)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VersionId).HasColumnName("VersionID");
            entity.Property(e => e.Xcharge)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('G')")
                .HasColumnName("XCharge");
            entity.Property(e => e.XchargeMethod).HasColumnName("XChargeMethod");
            entity.Property(e => e.XchargeMult)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("XChargeMult");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
