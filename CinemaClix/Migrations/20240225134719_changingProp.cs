using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class changingProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmbedCode",
                table: "watchListedMovies",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "watchListedMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "watchListedMovies");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "watchListedMovies",
                newName: "EmbedCode");
        }
    }
}
