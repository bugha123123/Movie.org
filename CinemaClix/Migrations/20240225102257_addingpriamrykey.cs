using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class addingpriamrykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWatchLists_Movies_MovieId",
                table: "UserWatchLists");

            migrationBuilder.DropIndex(
                name: "IX_UserWatchLists_MovieId",
                table: "UserWatchLists");

            migrationBuilder.CreateTable(
                name: "movieUserWatchLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserWatchListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieUserWatchLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movieUserWatchLists_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieUserWatchLists_UserWatchLists_UserWatchListId",
                        column: x => x.UserWatchListId,
                        principalTable: "UserWatchLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieUserWatchLists_MovieId",
                table: "movieUserWatchLists",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieUserWatchLists_UserWatchListId",
                table: "movieUserWatchLists",
                column: "UserWatchListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieUserWatchLists");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchLists_MovieId",
                table: "UserWatchLists",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWatchLists_Movies_MovieId",
                table: "UserWatchLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
