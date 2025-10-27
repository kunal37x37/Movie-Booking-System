using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Showtimes_ShowtimeId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ShowtimeId1",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ShowtimeId1",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 26, 9, 18, 4, 931, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 24, 16, 48, 4, 931, DateTimeKind.Local).AddTicks(4612));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId1",
                table: "Bookings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Genre", "ImageUrl", "IsActive", "Language", "ReleaseDate", "TicketPrice", "Title" },
                values: new object[] { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark knight investigation in Gotham city.", new TimeSpan(0, 2, 56, 0, 0), "Action", "/images/batman.jpg", true, "English", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.99m, "The Batman" });

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 24, 18, 30, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShowDateTime",
                value: new DateTime(2025, 10, 23, 15, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "IsActive", "MovieId", "ShowDateTime", "Theater", "TotalSeats" },
                values: new object[] { 3, 100, true, 3, new DateTime(2025, 10, 25, 20, 0, 0, 0, DateTimeKind.Local), "Cinepolis - Urban Center", 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowtimeId1",
                table: "Bookings",
                column: "ShowtimeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Showtimes_ShowtimeId1",
                table: "Bookings",
                column: "ShowtimeId1",
                principalTable: "Showtimes",
                principalColumn: "Id");
        }
    }
}
