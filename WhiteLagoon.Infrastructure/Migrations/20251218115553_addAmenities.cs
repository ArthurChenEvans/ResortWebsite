using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAmenities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumber_Villas_VillaId",
                table: "VillaNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VillaNumber",
                table: "VillaNumber");

            migrationBuilder.RenameTable(
                name: "VillaNumber",
                newName: "VillaNumbers");

            migrationBuilder.RenameIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumbers",
                newName: "IX_VillaNumbers_VillaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VillaNumbers",
                table: "VillaNumbers",
                column: "Villa_Number");

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    VillaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "Stunning infinity pool overlooking the ocean with automatic cleaning system", "Private Infinity Pool", 1 },
                    { 2, "Private stairway leading directly to the pristine white sand beach", "Beach Access", 1 },
                    { 3, "Spacious balcony with panoramic ocean views and comfortable seating", "Ocean View Balcony", 1 },
                    { 4, "Luxurious outdoor rainfall shower surrounded by tropical plants", "Outdoor Shower", 1 },
                    { 5, "Integrated smart home controls for lighting, climate, and entertainment", "Smart Home System", 1 },
                    { 6, "Authentic stone fireplace with wood-burning capability and heated mantel", "Stone Fireplace", 2 },
                    { 7, "Direct access to private hiking trails through scenic mountain forests", "Mountain Hiking Trails", 2 },
                    { 8, "Premium hot tub with hydrotherapy jets and mountain view", "Hot Tub", 2 },
                    { 9, "Traditional cedar wood sauna with aroma therapy options", "Wood Sauna", 2 },
                    { 10, "Radiant floor heating throughout the villa for cozy winter comfort", "Heated Floors", 2 },
                    { 11, "Professionally landscaped gardens with exotic plants and water features", "Tropical Gardens", 3 },
                    { 12, "Fully equipped outdoor kitchen with BBQ grill, sink, and bar seating", "Outdoor Kitchen", 3 },
                    { 13, "Large swimming pool with swim-up bar and underwater lighting", "Swimming Pool", 3 },
                    { 14, "Relaxing hammock area under palm trees with shade sails", "Hammock Area", 3 },
                    { 15, "Authentic tiki bar with thatched roof and tropical drink service", "Tiki Bar", 3 },
                    { 16, "Exclusive rooftop terrace with city views and lounge furniture", "Rooftop Terrace", 4 },
                    { 17, "Advanced smart home system with voice control and automation", "Smart Home System", 4 },
                    { 18, "Floor-to-ceiling windows offering breathtaking city skyline views", "City Skyline Views", 4 },
                    { 19, "Gigabit fiber internet with dedicated Wi-Fi 6 access points", "High-Speed Internet", 4 },
                    { 20, "24/7 concierge service for restaurant reservations and city experiences", "Concierge Service", 4 },
                    { 21, "Private wooden dock extending into the lake with seating area", "Private Dock", 5 },
                    { 22, "Stone fire pit with comfortable seating for lakeside evenings", "Fire Pit", 5 },
                    { 23, "Two-person canoe and two kayaks available for lake exploration", "Canoe/Kayak Access", 5 },
                    { 24, "Large covered patio with dining area and lake views", "Lakeside Patio", 5 },
                    { 25, "Professionally maintained botanical garden with walking paths", "Botanical Garden", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(1495), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(1994), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2226), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2227), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2229), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2232), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2232), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2234), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 18, 11, 55, 52, 753, DateTimeKind.Unspecified).AddTicks(2235), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VillaNumbers",
                table: "VillaNumbers");

            migrationBuilder.RenameTable(
                name: "VillaNumbers",
                newName: "VillaNumber");

            migrationBuilder.RenameIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumber",
                newName: "IX_VillaNumber_VillaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VillaNumber",
                table: "VillaNumber",
                column: "Villa_Number");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7548), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7876), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7877), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7881), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7881), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7883), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 58, 48, 162, DateTimeKind.Unspecified).AddTicks(7883), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumber_Villas_VillaId",
                table: "VillaNumber",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
