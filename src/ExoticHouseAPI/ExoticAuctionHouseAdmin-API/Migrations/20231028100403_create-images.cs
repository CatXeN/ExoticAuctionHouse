using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class createimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Cars");
        }
    }
}
