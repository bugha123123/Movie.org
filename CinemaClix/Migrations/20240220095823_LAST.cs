using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class LAST : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "https://m.media-amazon.com/images/M/MV5BMDZkYmVhNjMtNWU4MC00MDQxLWE3MjYtZGMzZWI1ZjhlOWJmXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "https://m.media-amazon.com/images/I/81XLYQOXR+L._AC_UF894,1000_QL80_.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "https://lh3.googleusercontent.com/proxy/S5hTfYeQAj733wEHrFzivW9KlBrYCJTAfwHKhI5AlzPb-bh40FYylMuDgj9P7mFQ9GJmTkn-nSo1effjOdQlMuTwc0mYzx24SVFcxg");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "https://lh3.googleusercontent.com/proxy/yi4kg53vZfPYG3zPmTrEljqiXaQ3fcJ7Zga8co09Uw74rQb_x3IhDeRK5cMAqN3jAmsd4xBF8tTVTNi7MMJOoyTtj4IyabdHjMHvPQ");
        }
    }
}
