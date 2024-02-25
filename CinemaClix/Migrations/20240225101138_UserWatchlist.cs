using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class UserWatchlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchLists_Movies_MoviesId",
                table: "UserWatchLists");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "UserWatchLists",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWatchLists_MoviesId",
                table: "UserWatchLists",
                newName: "IX_UserWatchLists_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "WatchListId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18,
                column: "WatchListId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19,
                column: "WatchListId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchLists_Movies_MovieId",
                table: "UserWatchLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchLists_Movies_MovieId",
                table: "UserWatchLists");

            migrationBuilder.DropColumn(
                name: "WatchListId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "UserWatchLists",
                newName: "MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWatchLists_MovieId",
                table: "UserWatchLists",
                newName: "IX_UserWatchLists_MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchLists_Movies_MoviesId",
                table: "UserWatchLists",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
