using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class addingShowBerlin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "$2a$11$SCSIY6FNAwLEkUQRxKMy8.d9CjSh8pRKlqngjJwEsvXBT28CpzviG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "PosterImage",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfVeTWX6IIR-5CYKdCr7InTf5dceCY3pvqkK4wQap25u3H8b_Y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Gyy/O6b9dyddvWRT.MYOb.fz6o3PFd7knhiJOFPmvdBCxlUqCqh1i");
        }
    }
}
