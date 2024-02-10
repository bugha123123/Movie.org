using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class EmbedCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmbedCode",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmbedCode",
                table: "Movies");
        }
    }
}
