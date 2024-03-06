using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class removingProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zRxlWk62iXE9kbx8risHCO5qJ//5j60kIQfqZjBkrqAddZurmNS6S");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "ProfileImage" },
                values: new object[] { "$2a$11$zfB0f3.yihCnTM62SB1cPOwPiWQJgwluW0qj9FLVcCVT39wx30Kcu", "https://thumbs.dreamstime.com/b/admin-sign-laptop-icon-stock-vector-166205404.jpg" });
        }
    }
}
