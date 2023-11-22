using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class ForeginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FollowedCars_CarId",
                table: "FollowedCars",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedCars_Cars_CarId",
                table: "FollowedCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowedCars_Cars_CarId",
                table: "FollowedCars");

            migrationBuilder.DropIndex(
                name: "IX_FollowedCars_CarId",
                table: "FollowedCars");

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("0ffe3e6a-94ea-4218-9682-efb5fd2ad134"), "Driver assistance system", "ESP" },
                    { new Guid("2101e8db-5a7a-450f-94a6-991eb8e4087f"), "Security", "ABS" },
                    { new Guid("2601ecf3-ee8a-493f-8836-5b7a2b05abbd"), "Audio and multimedia", "HIFI speaker" },
                    { new Guid("2dbc7600-a69f-44e3-940e-af055125bad9"), "Audio and multimedia", "USB socket" },
                    { new Guid("2f1505eb-d977-405a-b604-6da418bfa99b"), "Audio and multimedia", "Radio" },
                    { new Guid("301f3cf0-83c3-46e6-a801-19e98846c39e"), "Audio and multimedia", "Apple CarPlay" },
                    { new Guid("3a9c49bb-8271-442c-9dba-84804fcae7ce"), "Comfort and accessories", "Electrict windows" },
                    { new Guid("4703efb5-023b-4283-80e4-d7ec250265c6"), "Driver assistance system", "Heated side mirror" },
                    { new Guid("47419622-f81c-4cde-8fc1-c15a9195d9a1"), "Comfort and accessories", "Leather seats" },
                    { new Guid("544dad6f-4a43-433f-839d-a1c081d3a280"), "Audio and multimedia", "Interface Bluetooth" },
                    { new Guid("6defde8a-a93a-4ebf-89fd-b1fc7f77c055"), "Driver assistance system", "Park assistant" },
                    { new Guid("827a0994-a4fc-4cac-b330-f7a380c36c91"), "Security", "ESP" },
                    { new Guid("8aeba385-2812-4c88-9bc5-9e2e30f1364c"), "Driver assistance system", "Daytime running lights" },
                    { new Guid("912267ca-7c5c-4183-87a4-b52cbf1839ed"), "Comfort and accessories", "Leather steering wheel" },
                    { new Guid("a2d48c9a-094e-466e-a00c-f99b6fa585ce"), "Comfort and accessories", "Heated seats" },
                    { new Guid("af079b05-e76a-4eb8-a80c-0ee83efb76fb"), "Comfort and accessories", "Automatic air conditioning" },
                    { new Guid("b021441b-bb48-44d5-9e6e-0cbfa41393db"), "Security", "Isofix" },
                    { new Guid("b96d92ed-03db-4781-ac6c-827e228e8823"), "Driver assistance system", "System start/stop" },
                    { new Guid("bb1bd376-e2e5-4c4f-a37d-8095a9ecb0c5"), "Audio and multimedia", "Touchscreen" },
                    { new Guid("c02b611f-aa53-4ade-8cf9-27629ae13f18"), "Driver assistance system", "Fog lamps" },
                    { new Guid("c110d251-5300-4225-9f45-6171a620dfad"), "Audio and multimedia", "Android Auto" },
                    { new Guid("eec1befa-ae73-448b-94c5-af489e5e8e0b"), "Driver assistance system", "Power steering" },
                    { new Guid("f13b2c30-6d9b-46c0-9992-457c62aebef7"), "Comfort and accessories", "Multifunction steering wheel" },
                    { new Guid("f4ba1bae-2a41-4b0d-a9d6-b7be49e92d5a"), "Driver assistance system", "Headlights with LED technology" }
                });
        }
    }
}
