using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeason1Video : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmbedCode",
                table: "Shows",
                newName: "Season1");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "Season1",
                value: "[\"https://www.youtube.com/embed/mnd7sFt5c3A?si=olf4i4xqnbMRmnTp\"]");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Season1",
                value: "[\"https://www.youtube.com/embed/GSycMV-_Csw?si=NsNv6ChB8496b-W_\"]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Season1",
                table: "Shows",
                newName: "EmbedCode");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/mnd7sFt5c3A?si=olf4i4xqnbMRmnTp");

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/GSycMV-_Csw?si=NsNv6ChB8496b-W_");
        }
    }
}
