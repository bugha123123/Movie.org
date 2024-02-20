using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class ShowChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "PosterImage",
                value: "https://sm.ign.com/t/ign_me/review/s/stranger-t/stranger-things-season-1-review_fjsz.1200.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "PosterImage",
                value: "https://thecrimsonwhite.com/wp-content/uploads/2022/06/stranger-900x506.png");
        }
    }
}
