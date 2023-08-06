using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class IsSold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "AuctionHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "AuctionHistory");
        }
    }
}
