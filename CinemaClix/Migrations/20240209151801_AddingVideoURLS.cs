using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class AddingVideoURLS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/k10ETZ41q5o?si=nWLREnlD1OIxo-Ds");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/nIewKn6EnAs?si=OLrl6d4S8kE2lj_7");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/hEJnMQG9ev8?si=FuiIkFOQQ1ONZ9u_");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/wZdpNglLbt8?si=S5voA75MAG_mjVbq");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/BjJcYdEOI0k?si=BMadHTedURGAwZUI");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/gCcx85zbxz4?si=3lnpek05_TeduKqP");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/O3CIXEAjcc8?si=DdlJdpK5Xg8Wgrx3");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/Ue4PCI0NamI?si=quRuKTUJdxnjDrB0");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "EmbedCode",
                value: "https://www.youtube.com/embed/v8yrZSkKxTA?si=t4JzRlAXamclN8ux");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
