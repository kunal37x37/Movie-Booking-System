using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketCategory",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCategory",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 26, 12, 3, 28, 72, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 24, 19, 33, 28, 72, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 27, 13, 33, 28, 72, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 26, 8, 33, 28, 72, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 28, 14, 33, 28, 72, DateTimeKind.Local).AddTicks(4184));
        }
    }
}
