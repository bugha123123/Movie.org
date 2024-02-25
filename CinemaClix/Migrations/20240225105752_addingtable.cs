using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class addingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListedMovie_Movies_Movieid",
                table: "WatchListedMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchListedMovie",
                table: "WatchListedMovie");

            migrationBuilder.RenameTable(
                name: "WatchListedMovie",
                newName: "watchListedMovies");

            migrationBuilder.RenameIndex(
                name: "IX_WatchListedMovie_Movieid",
                table: "watchListedMovies",
                newName: "IX_watchListedMovies_Movieid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_watchListedMovies",
                table: "watchListedMovies",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_watchListedMovies_Movies_Movieid",
                table: "watchListedMovies",
                column: "Movieid",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watchListedMovies_Movies_Movieid",
                table: "watchListedMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_watchListedMovies",
                table: "watchListedMovies");

            migrationBuilder.RenameTable(
                name: "watchListedMovies",
                newName: "WatchListedMovie");

            migrationBuilder.RenameIndex(
                name: "IX_watchListedMovies_Movieid",
                table: "WatchListedMovie",
                newName: "IX_WatchListedMovie_Movieid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchListedMovie",
                table: "WatchListedMovie",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListedMovie_Movies_Movieid",
                table: "WatchListedMovie",
                column: "Movieid",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
