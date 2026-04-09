using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVillaImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/VillaImages/10875808-b728-427e-adda-f7af3d440eb4.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/VillaImages/f4f8af08-3a40-4ec6-be5f-f4c27a4d6c72.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/VillaImages/cc053911-6481-43cd-8ed7-5c81729482b4.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/VillaImages/51a31d12-18c4-4727-8a31-f14cfce149dc.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/VillaImages/bdad0648-9d64-4e4c-9579-abb192ab72ad.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://placehold.co/600x400/EEE/31343C");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://placehold.co/600x400/EEE/31343C");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://placehold.co/600x400/EEE/31343C");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://placehold.co/600x400/EEE/31343C");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://placehold.co/600x400/EEE/31343C");
        }
    }
}
