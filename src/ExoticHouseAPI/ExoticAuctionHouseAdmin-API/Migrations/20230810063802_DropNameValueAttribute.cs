using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class DropNameValueAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CarAttributes");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "CarAttributes",
                newName: "Attributes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attributes",
                table: "CarAttributes",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CarAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
