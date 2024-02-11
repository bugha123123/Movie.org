using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class AddingRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: "⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: "⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: "⭐⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: "⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: "⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: "⭐⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: "⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: "⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: "⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: "⭐⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "Rating",
                value: "⭐⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "Rating",
                value: "⭐⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Rating",
                value: "⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "Rating",
                value: "⭐⭐⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "Rating",
                value: "⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Genre", "Rating" },
                values: new object[] { "Action", "⭐⭐⭐" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Rating",
                value: "⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18,
                column: "Rating",
                value: "⭐⭐⭐");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Rating",
                value: "⭐");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "Genre",
                value: "Sci-Fi");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "EmbedCode", "Genre", "Image", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 20, "A man with a low IQ experiences key historical events.", "https://www.youtube.com/embed/bLvqoHBptjg?si=j8yWcQDqRTy2qUuE", "Drama", "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00YzQyLWE4NGMtNjM0ZDQyMmMwMzFkXkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_FMjpg_UX1000_.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { 21, "A computer hacker learns shocking truths about reality.", "https://www.youtube.com/embed/m8e-FF8MsqU?si=8sou_wIiTMqUCsIo", "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_FMjpg_UX1000_.jpg", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });
        }
    }
}
