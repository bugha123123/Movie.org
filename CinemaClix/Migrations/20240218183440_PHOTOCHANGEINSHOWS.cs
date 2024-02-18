using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class PHOTOCHANGEINSHOWS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "https://lh3.googleusercontent.com/proxy/Alfwg5PjO6uO1LAUdHmPfjnJhJj6TkEWJuEb8eP02B8SLHL64nazlj50HFjl59dpnZnqHeGTl5B-esJUp-ijhDJKAZce9sMDAWO_a9FP-FXk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "https://upload.wikimedia.org/wikipedia/en/1/19/Reacher_TV_poster.jpg");
        }
    }
}
