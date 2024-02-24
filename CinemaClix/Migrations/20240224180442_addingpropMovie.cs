using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class addingpropMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserWatchLists_WatchListedMovieId",
                table: "UserWatchLists",
                column: "WatchListedMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchLists_Movies_WatchListedMovieId",
                table: "UserWatchLists",
                column: "WatchListedMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchLists_Movies_WatchListedMovieId",
                table: "UserWatchLists");

            migrationBuilder.DropIndex(
                name: "IX_UserWatchLists_WatchListedMovieId",
                table: "UserWatchLists");
        }
    }
}
