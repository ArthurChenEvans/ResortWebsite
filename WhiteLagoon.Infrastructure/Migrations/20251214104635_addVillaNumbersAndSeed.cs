using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addVillaNumbersAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Villas",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VillaId = table.Column<int>(type: "integer", nullable: false),
                    SpecialDetails = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumber_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VillaNumber",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, "Ocean view balcony with private hot tub", 1 },
                    { 102, "Ground floor access, wheelchair accessible", 1 },
                    { 103, "Rooftop terrace with telescope for stargazing", 1 },
                    { 201, "Forest-facing room with suspended fireplace", 2 },
                    { 202, "Private sauna and cold plunge pool access", 2 },
                    { 203, "Artist's studio with natural lighting", 2 },
                    { 301, "Infinity pool edge overlooking tropical gardens", 3 },
                    { 302, "Chef's kitchenette with premium appliances", 3 },
                    { 303, "Glass-walled bedroom with jungle canopy views", 3 },
                    { 401, "Soundproofed media room with 4K projector", 4 },
                    { 402, "Executive workspace with ergonomic setup", 4 },
                    { 403, "Penthouse suite with 360° city skyline views", 4 },
                    { 501, "Lakeside deck with private canoe dock", 5 },
                    { 502, "Indoor/outdoor fireplace with lakeside seating", 5 },
                    { 503, "Botanical garden conservatory with breakfast nook", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(2031), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(2908), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3155), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3156), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3158), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3161), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 12, 14, 10, 46, 34, 383, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumber",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Villas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3173), new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3383) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3612), new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3614), new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3616), new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3616) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3618), new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3618) });
        }
    }
}
