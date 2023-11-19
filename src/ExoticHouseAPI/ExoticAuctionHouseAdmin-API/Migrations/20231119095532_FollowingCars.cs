using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class FollowingCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("019fa335-ebf1-4dde-b6f1-7b4056d34c07"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("118c3241-9e97-49b3-94aa-3a3d2829b7df"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("17681eeb-b3e1-4595-b180-b2d9cb468ee8"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("1b8fe7ca-0cad-4aed-875e-fbe85d5dab44"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3375157f-b150-4e53-9ce7-c34a9e48e08e"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("38cb367b-d44d-4f14-b0c4-dcfbfc295b9c"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a99a83f-3cc0-4eeb-bda8-a511bb12f2e2"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3f429e2a-df3f-47ed-bd5e-7db91b904691"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("55107aef-6741-4ddb-8ab8-715fe0beded9"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("5a5e8d7b-5669-455f-978e-c6f8ae4092f6"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6aa5af41-dd8a-4db9-9145-ad9248781dd1"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("78f40800-0f96-44aa-bfb1-824380ca7ce9"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("7ef7c8a7-00e0-4294-9b7d-db5160ce06ce"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("845ee16f-bf05-4032-a27a-7ff8ec0315db"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("966429a0-7302-4f99-b3ab-08ad891bac58"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("96ef2bdc-17bf-4c74-85d6-482862376515"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("97152f01-55a6-48e4-a1f8-5a691e2f9a9c"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("9f351cdc-5964-49e7-b120-7b51dc4a8c81"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("9faa7a78-fac6-4dcb-b470-5bc1cdc6d8fa"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("d20cccb0-0c09-4d95-8035-2d7b324e9ca8"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("d512a363-6e95-48b9-ab88-ec629eedcb2c"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("d9f5f533-d571-4f5a-9f20-f9db04a6dec1"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("e7a5707b-6f04-49a0-b1c6-d91fb13f9716"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("e9bca008-430c-42e4-9e85-1fd86cb712fd"));

            migrationBuilder.CreateTable(
                name: "FollowedCars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedCars", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowedCars");

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("0ffe3e6a-94ea-4218-9682-efb5fd2ad134"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2101e8db-5a7a-450f-94a6-991eb8e4087f"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2601ecf3-ee8a-493f-8836-5b7a2b05abbd"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2dbc7600-a69f-44e3-940e-af055125bad9"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("2f1505eb-d977-405a-b604-6da418bfa99b"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("301f3cf0-83c3-46e6-a801-19e98846c39e"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("3a9c49bb-8271-442c-9dba-84804fcae7ce"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("4703efb5-023b-4283-80e4-d7ec250265c6"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("47419622-f81c-4cde-8fc1-c15a9195d9a1"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("544dad6f-4a43-433f-839d-a1c081d3a280"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("6defde8a-a93a-4ebf-89fd-b1fc7f77c055"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("827a0994-a4fc-4cac-b330-f7a380c36c91"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("8aeba385-2812-4c88-9bc5-9e2e30f1364c"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("912267ca-7c5c-4183-87a4-b52cbf1839ed"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("a2d48c9a-094e-466e-a00c-f99b6fa585ce"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("af079b05-e76a-4eb8-a80c-0ee83efb76fb"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("b021441b-bb48-44d5-9e6e-0cbfa41393db"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("b96d92ed-03db-4781-ac6c-827e228e8823"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("bb1bd376-e2e5-4c4f-a37d-8095a9ecb0c5"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c02b611f-aa53-4ade-8cf9-27629ae13f18"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("c110d251-5300-4225-9f45-6171a620dfad"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("eec1befa-ae73-448b-94c5-af489e5e8e0b"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f13b2c30-6d9b-46c0-9992-457c62aebef7"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("f4ba1bae-2a41-4b0d-a9d6-b7be49e92d5a"));

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("019fa335-ebf1-4dde-b6f1-7b4056d34c07"), "Driver assistance system", "ESP" },
                    { new Guid("118c3241-9e97-49b3-94aa-3a3d2829b7df"), "Audio and multimedia", "Android Auto" },
                    { new Guid("17681eeb-b3e1-4595-b180-b2d9cb468ee8"), "Audio and multimedia", "HIFI speaker" },
                    { new Guid("1b8fe7ca-0cad-4aed-875e-fbe85d5dab44"), "Driver assistance system", "Fog lamps" },
                    { new Guid("3375157f-b150-4e53-9ce7-c34a9e48e08e"), "Driver assistance system", "Headlights with LED technology" },
                    { new Guid("38cb367b-d44d-4f14-b0c4-dcfbfc295b9c"), "Comfort and accessories", "Automatic air conditioning" },
                    { new Guid("3a99a83f-3cc0-4eeb-bda8-a511bb12f2e2"), "Driver assistance system", "Heated side mirror" },
                    { new Guid("3f429e2a-df3f-47ed-bd5e-7db91b904691"), "Comfort and accessories", "Leather steering wheel" },
                    { new Guid("55107aef-6741-4ddb-8ab8-715fe0beded9"), "Security", "ESP" },
                    { new Guid("5a5e8d7b-5669-455f-978e-c6f8ae4092f6"), "Security", "ABS" },
                    { new Guid("6aa5af41-dd8a-4db9-9145-ad9248781dd1"), "Comfort and accessories", "Heated seats" },
                    { new Guid("78f40800-0f96-44aa-bfb1-824380ca7ce9"), "Driver assistance system", "Park assistant" },
                    { new Guid("7ef7c8a7-00e0-4294-9b7d-db5160ce06ce"), "Audio and multimedia", "Interface Bluetooth" },
                    { new Guid("845ee16f-bf05-4032-a27a-7ff8ec0315db"), "Driver assistance system", "Power steering" },
                    { new Guid("966429a0-7302-4f99-b3ab-08ad891bac58"), "Driver assistance system", "Daytime running lights" },
                    { new Guid("96ef2bdc-17bf-4c74-85d6-482862376515"), "Audio and multimedia", "Touchscreen" },
                    { new Guid("97152f01-55a6-48e4-a1f8-5a691e2f9a9c"), "Comfort and accessories", "Electrict windows" },
                    { new Guid("9f351cdc-5964-49e7-b120-7b51dc4a8c81"), "Comfort and accessories", "Leather seats" },
                    { new Guid("9faa7a78-fac6-4dcb-b470-5bc1cdc6d8fa"), "Audio and multimedia", "USB socket" },
                    { new Guid("d20cccb0-0c09-4d95-8035-2d7b324e9ca8"), "Audio and multimedia", "Apple CarPlay" },
                    { new Guid("d512a363-6e95-48b9-ab88-ec629eedcb2c"), "Driver assistance system", "System start/stop" },
                    { new Guid("d9f5f533-d571-4f5a-9f20-f9db04a6dec1"), "Security", "Isofix" },
                    { new Guid("e7a5707b-6f04-49a0-b1c6-d91fb13f9716"), "Comfort and accessories", "Multifunction steering wheel" },
                    { new Guid("e9bca008-430c-42e4-9e85-1fd86cb712fd"), "Audio and multimedia", "Radio" }
                });
        }
    }
}
