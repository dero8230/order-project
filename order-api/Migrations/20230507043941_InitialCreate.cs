using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace order_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderAdmins",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainUserName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    DetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PricingID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Quantity = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    BindInSet = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Pages = table.Column<int>(type: "int", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompletedBy = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    FileStaged = table.Column<bool>(type: "bit", nullable: true),
                    FileArchived = table.Column<bool>(type: "bit", nullable: true),
                    FileQC = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.DetailsID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemPricing",
                columns: table => new
                {
                    PricingID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    Item = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Color = table.Column<bool>(type: "bit", nullable: true),
                    Size = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cost = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    MasterDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    AccountCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    HasFile = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProjectNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PrintingFor = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateRequired = table.Column<DateTime>(type: "datetime", nullable: true),
                    SpecialInstructions = table.Column<string>(type: "text", nullable: true),
                    OrderType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    OrderLink = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    SubmittedBy = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    OrderComplete = table.Column<bool>(type: "bit", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VisionExportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NotifyEmployee = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    NotifyEmployee2 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Extras = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "OrderSignAndSeal",
                columns: table => new
                {
                    SSID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Electronic = table.Column<bool>(type: "bit", nullable: true),
                    ArchSignee = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ArchCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MechSignee = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MechCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ElectSignee = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ElectCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlumbSignee = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PlumbCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CivilSignee = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CivilCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StructSignee = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StructCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LeadPermit = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LeadPermitCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ArchSigner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MechSigner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ElectSigner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PlumbSigner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CivilSigner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StructSigner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSignAndSeal", x => x.SSID);
                });

            migrationBuilder.CreateTable(
                name: "OrderSignees",
                columns: table => new
                {
                    DisplayName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Discipline = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PaperSize",
                columns: table => new
                {
                    PaperSizes = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaperSize_PaperSizes",
                table: "PaperSize",
                column: "PaperSizes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAdmins");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderItemPricing");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderSignAndSeal");

            migrationBuilder.DropTable(
                name: "OrderSignees");

            migrationBuilder.DropTable(
                name: "PaperSize");
        }
    }
}
