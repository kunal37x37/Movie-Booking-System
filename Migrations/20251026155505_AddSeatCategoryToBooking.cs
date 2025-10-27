using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatCategoryToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketCategory",
                table: "Bookings",
                newName: "SeatCategory");

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 28, 15, 55, 4, 627, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 26, 23, 25, 4, 627, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 29, 17, 25, 4, 627, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 28, 12, 25, 4, 627, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 30, 18, 25, 4, 627, DateTimeKind.Local).AddTicks(3356));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatCategory",
                table: "Bookings",
                newName: "TicketCategory");

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 27, 11, 9, 30, 517, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 25, 18, 39, 30, 517, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 28, 12, 39, 30, 517, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 27, 7, 39, 30, 517, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 29, 13, 39, 30, 517, DateTimeKind.Local).AddTicks(8699));
        }
    }
}
