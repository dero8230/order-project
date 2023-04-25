using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using order_api.Models.PR;

namespace order_api.Models;

public partial class PlotroomOrdersContext : DbContext
{
    private readonly IConfiguration _configuration;
    public PlotroomOrdersContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public PlotroomOrdersContext(DbContextOptions<PlotroomOrdersContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderAdmin> OrderAdmins { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderItemPricing> OrderItemPricings { get; set; }

    public virtual DbSet<OrderSignAndSeal> OrderSignAndSeals { get; set; }

    public virtual DbSet<OrderSignee> OrderSignees { get; set; }
    public virtual DbSet<PaperSize> PaperSize { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetSection("PlotroomOrdersDb").Value);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PaperSizeConfiguration());
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.DateRequired).HasColumnType("datetime");
            entity.Property(e => e.DateSubmitted).HasColumnType("datetime");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.NotifyEmployee)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.NotifyEmployee2)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.OrderLink).IsUnicode(false);
            entity.Property(e => e.OrderType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PrintingFor)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ProjectNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpecialInstructions).HasColumnType("text");
            entity.Property(e => e.SubmittedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VisionExportDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderAdmin>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DomainUserName).IsUnicode(false);
            entity.Property(e => e.PrimaryKey).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.CompletedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateCompleted).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DetailsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DetailsID");
            entity.Property(e => e.FileQc).HasColumnName("FileQC");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.PricingId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PricingID");
            entity.Property(e => e.Quantity)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderItemPricing>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OrderItemPricing");

            entity.Property(e => e.AccountCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Item)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MasterDescription).IsUnicode(false);
            entity.Property(e => e.PricingId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PricingID");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderSignAndSeal>(entity =>
        {
            entity
                .ToTable("OrderSignAndSeal");

            entity.Property(e => e.ArchCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.ArchSignee)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ArchSigner)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CivilCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CivilSignee)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CivilSigner)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateCompleted).HasColumnType("datetime");
            entity.Property(e => e.ElectCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.ElectSignee)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ElectSigner)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LeadPermit)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LeadPermitCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.MechCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.MechSignee)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MechSigner)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.PlumbCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.PlumbSignee)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PlumbSigner)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ssid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SSID");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StructCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.StructSignee)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StructSigner)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderSignee>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Discipline).IsUnicode(false);
            entity.Property(e => e.DisplayName).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
