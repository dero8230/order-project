﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using order_api.Models;

#nullable disable

namespace order_api.Migrations
{
    [DbContext(typeof(PlotroomOrdersContext))]
    partial class PlotroomOrdersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("order_api.Models.Invoice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmittedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("order_api.Models.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("OrderID");

                    b.Property<DateTime?>("DateRequired")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateSubmitted")
                        .HasColumnType("datetime");

                    b.Property<string>("Extras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NotifyEmployee")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("NotifyEmployee2")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<bool?>("OrderComplete")
                        .HasColumnType("bit");

                    b.Property<string>("OrderLink")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("OrderType")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PrintingFor")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ProjectNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SpecialInstructions")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SubmittedBy")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("VisionExportDate")
                        .HasColumnType("datetime");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("order_api.Models.OrderAdmin", b =>
                {
                    b.Property<string>("DomainUserName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrimaryKey"));

                    b.ToTable("OrderAdmins");
                });

            modelBuilder.Entity("order_api.Models.OrderDetail", b =>
                {
                    b.Property<int>("DetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DetailsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailsId"));

                    b.Property<bool?>("BindInSet")
                        .HasColumnType("bit");

                    b.Property<bool?>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("CompletedBy")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool?>("FileArchived")
                        .HasColumnType("bit");

                    b.Property<bool?>("FileQc")
                        .HasColumnType("bit")
                        .HasColumnName("FileQC");

                    b.Property<bool?>("FileStaged")
                        .HasColumnType("bit");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("OrderID");

                    b.Property<int?>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("PricingId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PricingID");

                    b.Property<string>("Quantity")
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)");

                    b.HasKey("DetailsId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("order_api.Models.OrderItemPricing", b =>
                {
                    b.Property<string>("AccountCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<bool?>("Color")
                        .HasColumnType("bit");

                    b.Property<string>("Cost")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("HasFile")
                        .HasColumnType("bit");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MasterDescription")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<Guid?>("PricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PricingID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("ReferenceNumber")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.ToTable("OrderItemPricing", (string)null);
                });

            modelBuilder.Entity("order_api.Models.OrderSignAndSeal", b =>
                {
                    b.Property<int>("Ssid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SSID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ssid"));

                    b.Property<DateTime?>("ArchCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ArchSignee")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ArchSigner")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("CivilCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CivilSignee")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CivilSigner")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool?>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ElectCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ElectSignee")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ElectSigner")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool?>("Electronic")
                        .HasColumnType("bit");

                    b.Property<string>("LeadPermit")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("LeadPermitCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("MechCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MechSignee")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MechSigner")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("OrderID");

                    b.Property<DateTime?>("PlumbCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PlumbSignee")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PlumbSigner")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("StructCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("StructSignee")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StructSigner")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Ssid");

                    b.ToTable("OrderSignAndSeal", (string)null);
                });

            modelBuilder.Entity("order_api.Models.OrderSignee", b =>
                {
                    b.Property<string>("Discipline")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.ToTable("OrderSignees");
                });

            modelBuilder.Entity("order_api.Models.PR.PaperSize", b =>
                {
                    b.Property<string>("Cost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cost");

                    b.Property<string>("PaperSizes")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("PaperSizes");

                    b.HasIndex("PaperSizes");

                    b.ToTable("PaperSize");
                });
#pragma warning restore 612, 618
        }
    }
}
