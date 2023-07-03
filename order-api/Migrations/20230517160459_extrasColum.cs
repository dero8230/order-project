using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace order_api.Migrations
{
    /// <inheritdoc />
    public partial class extrasColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extras",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extras",
                table: "Orders");
        }
    }
}
