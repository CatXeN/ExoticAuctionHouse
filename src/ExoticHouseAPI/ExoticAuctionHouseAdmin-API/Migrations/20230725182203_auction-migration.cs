using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class auctionmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Horsepower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Auctions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Horsepower",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Auctions");
        }
    }
}
