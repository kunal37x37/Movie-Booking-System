using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId1",
                table: "Bookings",
                type: "INTEGER",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Showtimes_ShowtimeId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ShowtimeId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ShowtimeId1",
                table: "Bookings");
        }
    }
}
