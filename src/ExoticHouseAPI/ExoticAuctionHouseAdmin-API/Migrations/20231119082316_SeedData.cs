using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExoticAuctionHouse_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
