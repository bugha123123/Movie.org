using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserWatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchLists_Movies_WatchListedMovieId",
                table: "UserWatchLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserWatchLists");

            migrationBuilder.RenameColumn(
                name: "WatchListedMovieId",
                table: "UserWatchLists",
                newName: "MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWatchLists_WatchListedMovieId",
                table: "UserWatchLists",
                newName: "IX_UserWatchLists_MoviesId");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "UserWatchLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchLists_Movies_MoviesId",
                table: "UserWatchLists",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchLists_Movies_MoviesId",
                table: "UserWatchLists");

            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "UserWatchLists");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "UserWatchLists",
                newName: "WatchListedMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWatchLists_MoviesId",
                table: "UserWatchLists",
                newName: "IX_UserWatchLists_WatchListedMovieId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserWatchLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchLists_Movies_WatchListedMovieId",
                table: "UserWatchLists",
                column: "WatchListedMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
