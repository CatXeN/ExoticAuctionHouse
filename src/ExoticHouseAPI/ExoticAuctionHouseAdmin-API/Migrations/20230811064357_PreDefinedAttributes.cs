using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class PreDefinedAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attributes",
                table: "CarAttributes");

            migrationBuilder.AddColumn<Guid>(
                name: "AttributeId",
                table: "CarAttributes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarAttributes_AttributeId",
                table: "CarAttributes",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarAttributes_Attributes_AttributeId",
                table: "CarAttributes",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarAttributes_Attributes_AttributeId",
                table: "CarAttributes");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_CarAttributes_AttributeId",
                table: "CarAttributes");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "CarAttributes");

            migrationBuilder.AddColumn<string>(
                name: "Attributes",
                table: "CarAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
