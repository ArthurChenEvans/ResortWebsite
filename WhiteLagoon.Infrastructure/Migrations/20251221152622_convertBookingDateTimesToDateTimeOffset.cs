using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class convertBookingDateTimesToDateTimeOffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StripeSessionId",
                table: "Bookings",
                newName: "BraintreeTransactionId");

            migrationBuilder.RenameColumn(
                name: "StripePaymentIntentId",
                table: "Bookings",
                newName: "BraintreePaymentNonce");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 21, 15, 26, 21, 507, DateTimeKind.Unspecified).AddTicks(2070), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 21, 15, 26, 21, 507, DateTimeKind.Unspecified).AddTicks(3943), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 21, 15, 26, 21, 507, DateTimeKind.Unspecified).AddTicks(3948), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 21, 15, 26, 21, 507, DateTimeKind.Unspecified).AddTicks(3954), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 21, 15, 26, 21, 507, DateTimeKind.Unspecified).AddTicks(3956), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BraintreeTransactionId",
                table: "Bookings",
                newName: "StripeSessionId");

            migrationBuilder.RenameColumn(
                name: "BraintreePaymentNonce",
                table: "Bookings",
                newName: "StripePaymentIntentId");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 20, 15, 27, 24, 653, DateTimeKind.Unspecified).AddTicks(2489), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 20, 15, 27, 24, 653, DateTimeKind.Unspecified).AddTicks(3790), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 20, 15, 27, 24, 653, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 20, 15, 27, 24, 653, DateTimeKind.Unspecified).AddTicks(3796), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 12, 20, 15, 27, 24, 653, DateTimeKind.Unspecified).AddTicks(3798), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
