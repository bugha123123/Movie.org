using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class ChangingLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "PosterImage",
                value: "https://image.tmdb.org/t/p/original/pIo3gcVF57JSjo6r9kQbySYZW4L.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$BJnu5WMqz/MErpPuN4s1ueDn4uoErRGYhyganRlNnMDxfBsnCtZBK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "PosterImage",
                value: "https://lh3.googleusercontent.com/proxy/zSQNq-W_F-LrBIW3Kj2PMrwM7leoduMl8s4OiZReuPGG8eYALHyyxePsMCwuw7bSQk5194jyFnjUcMXfuEuHN0N92DmJjvXAjxD8zd7omPCXFP9YgIQ");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CImZwu7CWHp1WQqtkWl8YusKnRNTVCd2WN4f/TCsDZ1oEjzA.4wHO");
        }
    }
}
