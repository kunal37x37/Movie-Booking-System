using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatCategoriesAndIndianPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "TicketPrice",
                value: 280m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "TicketPrice",
                value: 250m);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Genre", "ImageUrl", "IsActive", "Language", "ReleaseDate", "TicketPrice", "Title" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark knight investigation in Gotham city.", new TimeSpan(0, 2, 56, 0, 0), "Action", "/images/batman.jpg", true, "English", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 220m, "The Batman" },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A fictional story about two Indian revolutionaries.", new TimeSpan(0, 3, 7, 0, 0), "Action/Drama", "/images/rrr.jpg", true, "Hindi/Telugu", new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, "RRR" },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky continues his rise to power in the gold mining world.", new TimeSpan(0, 2, 48, 0, 0), "Action", "/images/kgf2.jpg", true, "Hindi/Kannada", new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 180m, "KGF Chapter 2" }
                });

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

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "IsActive", "MovieId", "ShowDateTime", "Theater", "TotalSeats" },
                values: new object[,]
                {
                    { 3, 100, true, 3, new DateTime(2025, 10, 27, 13, 33, 28, 72, DateTimeKind.Local).AddTicks(4179), "Cinepolis - Urban Center", 100 },
                    { 4, 200, true, 4, new DateTime(2025, 10, 26, 8, 33, 28, 72, DateTimeKind.Local).AddTicks(4182), "PVR Cinemas - Phoenix Mall", 200 },
                    { 5, 180, true, 5, new DateTime(2025, 10, 28, 14, 33, 28, 72, DateTimeKind.Local).AddTicks(4184), "INOX - Nexus Mall", 180 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "TicketPrice",
                value: 12.99m);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "TicketPrice",
                value: 11.99m);

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
    }
}
