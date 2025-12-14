using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillatoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "MeterSquared", "Name", "Occupancy", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3173), "A serene coastal villa with panoramic ocean views and a private infinity pool.", "https://placehold.co/600x400/EEE/31343C", 220, "Azure Haven", 6, 450.0, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3383) },
                    { 2, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3612), "Nestled in the mountains, this rustic-chic villa offers fireplace warmth and forest trails.", "https://placehold.co/600x400/EEE/31343C", 180, "Pinecrest Lodge", 4, 320.5, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3612) },
                    { 3, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3614), "Luxury meets comfort in this sun-drenched villa with tropical gardens and outdoor kitchen.", "https://placehold.co/600x400/EEE/31343C", 260, "Sunny Palms Estate", 8, 580.75, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3614) },
                    { 4, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3616), "Modern city-center villa with floor-to-ceiling windows and rooftop terrace access.", "https://placehold.co/600x400/EEE/31343C", 140, "Urban Loft Retreat", 3, 290.0, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3616) },
                    { 5, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3618), "Tranquil lakeside property with canoe dock, fire pit, and cozy interior design.", "https://placehold.co/600x400/EEE/31343C", 200, "Lakeside Serenity", 5, 410.25, new DateTime(2025, 12, 14, 6, 54, 10, 312, DateTimeKind.Utc).AddTicks(3618) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
