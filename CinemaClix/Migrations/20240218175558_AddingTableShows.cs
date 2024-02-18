using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class AddingTableShows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Show",
                table: "Show");

            migrationBuilder.RenameTable(
                name: "Show",
                newName: "Shows");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shows",
                table: "Shows",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shows",
                table: "Shows");

            migrationBuilder.RenameTable(
                name: "Shows",
                newName: "Show");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Show",
                table: "Show",
                column: "Id");
        }
    }
}
