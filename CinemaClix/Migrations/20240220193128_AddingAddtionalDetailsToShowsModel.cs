using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class AddingAddtionalDetailsToShowsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DirectorPhoto",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Shows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Shows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cast", "Director", "DirectorPhoto", "Rating", "ReleaseDate" },
                values: new object[] { "[\"https://people.com/thmb/hwBdMyWZOAXw9UnBe2qQfnyHepo=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/caleb-2000-bbffc3890d6d4ae2a3f348829f35216a.jpg\",\"https://people.com/thmb/EVHoFjXXjVnTZOjm1YYbIxYM2CI=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/millie2-2000-d8a6aaace09a42838c65dde7b4a28802.jpg\",\"https://people.com/thmb/YqYhcAUzArq0Wi4lyCnGepSofL8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/charlie-2000-e5e0595535fc48f08ef70757d8405432.jpg\",\"https://people.com/thmb/vKmZ4PRmW5hxggoqPVB1vnTaJCk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/natalia-2000-40091f6a9dbf491b88b669ac38c39888.jpg\",\"https://people.com/thmb/fyKBmN-cOaEQsvYmCZ-26AG9ngw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/gaten-2000-48499c525a7c42259b95322b423fa7bb.jpg\"]", "Duffer Brothers", "https://www.dga.org/-/media/Images/DGAQ-Article-Images/1703-Summer-2017/DGAQSummer2017GenNextDufferBrothers.ashx?la=en&hash=4F8968AAA3974674E109777DC46D45C2E890C353", 4.5999999999999996, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cast", "Director", "DirectorPhoto", "Rating", "ReleaseDate" },
                values: new object[] { "[\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Alan-Ritchson-plays-Jack-Reacher-a055dcb.jpg?quality=90\\u0026fit=700,466\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Hugh-Thompson-plays-Baker-e72f064.jpg?quality=90\\u0026fit=700,466\",\"http://t1.gstatic.com/images?q=tbn:ANd9GcQF4q-z9k7fFnNcKkytdApskFiKgpg-yFFn1Jfy5F6cmpeIETYU\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Malcolm-Goodwin-plays-Oscar-Finley-3d21000.jpg?quality=90\\u0026fit=700,466\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Willa-Fitzgerald-plays-Roscoe-Conklin-43a4a95.jpg?quality=90\\u0026fit=700,466\"]", "Christopher McQuarrie", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/de/Christopher_McQuarrie_2022.jpg/220px-Christopher_McQuarrie_2022.jpg", 3.0, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "DirectorPhoto",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Shows");
        }
    }
}
