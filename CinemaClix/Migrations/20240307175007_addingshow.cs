using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class addingshow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cast", "Description", "Director", "DirectorPhoto", "Genre", "Length", "Photo", "PosterImage", "Rating", "ReleaseDate", "Season1", "Season2", "Seasons", "ShowName" },
                values: new object[] { "[\"https://t3.gstatic.com/licensed-image?q=tbn:ANd9GcRygWWezFRqkaVOafu52-4aFqHI8H77UO5gQDUyDbVVmeFfVFmqxYIJUcQefTKQ6cKY\",\"http://t0.gstatic.com/images?q=tbn:ANd9GcSBCxxrYlppXCwIZuMhMeO-BYpfrFnVXL9HDSU9_zuOsMT2csgN\",\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcST053xPWPjsgcSrAMHSGTB4F4-OH5yMtXSIMkMb5ZMG3ctSRWN\"]", "Berlin (also known as Money Heist: Berlin, in Spanish La casa de papel: Berlín) is a Spanish TV series created by Álex Pina and Esther Martínez Lobato for Netflix.[", "Álex Pina\r\nEsther Martínez Lobato", "https://upload.wikimedia.org/wikipedia/commons/9/96/Alex_Pina%2C_Mercedes_Gamero_and_Alex_Garcia_at_MIFF_%28cropped%29.jpg", "Drama", "6h 50min", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfVeTWX6IIR-5CYKdCr7InTf5dceCY3pvqkK4wQap25u3H8b_Y", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfVeTWX6IIR-5CYKdCr7InTf5dceCY3pvqkK4wQap25u3H8b_Y", 5.0, new DateTime(2008, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[\"https://www.youtube.com/embed/XD_MLvGrGCY?si=VGsw5GTZqTHIe_Fp\"]", null, "1", "Berlin" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Cast", "Description", "Director", "DirectorPhoto", "Genre", "Length", "Photo", "PosterImage", "Rating", "ReleaseDate", "Season1", "Season2", "Seasons", "ShowName" },
                values: new object[] { 3, "[\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Alan-Ritchson-plays-Jack-Reacher-a055dcb.jpg?quality=90\\u0026fit=700,466\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Hugh-Thompson-plays-Baker-e72f064.jpg?quality=90\\u0026fit=700,466\",\"http://t1.gstatic.com/images?q=tbn:ANd9GcQF4q-z9k7fFnNcKkytdApskFiKgpg-yFFn1Jfy5F6cmpeIETYU\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Malcolm-Goodwin-plays-Oscar-Finley-3d21000.jpg?quality=90\\u0026fit=700,466\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Willa-Fitzgerald-plays-Roscoe-Conklin-43a4a95.jpg?quality=90\\u0026fit=700,466\"]", "Reacher is an American action crime streaming television series developed by Nick Santora for Amazon Prime Video", "Christopher McQuarrie", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/de/Christopher_McQuarrie_2022.jpg/220px-Christopher_McQuarrie_2022.jpg", "Action", "4h 50min", "https://m.media-amazon.com/images/I/81XLYQOXR+L._AC_UF894,1000_QL80_.jpg", "https://blog.richersounds.com/wp-content/uploads/2022/03/1_mEMiafsmsUsSs4eD-rd8_Q.jpeg", 3.0, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[\"https://www.youtube.com/embed/GSycMV-_Csw?si=NsNv6ChB8496b-W_\"]", "[\"https://www.youtube.com/embed/tC-rRhQcnlI?si=SoatFGlxAsmBN7fD\"]", "2", "Reacher" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Gyy/O6b9dyddvWRT.MYOb.fz6o3PFd7knhiJOFPmvdBCxlUqCqh1i");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cast", "Description", "Director", "DirectorPhoto", "Genre", "Length", "Photo", "PosterImage", "Rating", "ReleaseDate", "Season1", "Season2", "Seasons", "ShowName" },
                values: new object[] { "[\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Alan-Ritchson-plays-Jack-Reacher-a055dcb.jpg?quality=90\\u0026fit=700,466\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Hugh-Thompson-plays-Baker-e72f064.jpg?quality=90\\u0026fit=700,466\",\"http://t1.gstatic.com/images?q=tbn:ANd9GcQF4q-z9k7fFnNcKkytdApskFiKgpg-yFFn1Jfy5F6cmpeIETYU\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Malcolm-Goodwin-plays-Oscar-Finley-3d21000.jpg?quality=90\\u0026fit=700,466\",\"https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Willa-Fitzgerald-plays-Roscoe-Conklin-43a4a95.jpg?quality=90\\u0026fit=700,466\"]", "Reacher is an American action crime streaming television series developed by Nick Santora for Amazon Prime Video", "Christopher McQuarrie", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/de/Christopher_McQuarrie_2022.jpg/220px-Christopher_McQuarrie_2022.jpg", "Action", "4h 50min", "https://m.media-amazon.com/images/I/81XLYQOXR+L._AC_UF894,1000_QL80_.jpg", "https://blog.richersounds.com/wp-content/uploads/2022/03/1_mEMiafsmsUsSs4eD-rd8_Q.jpeg", 3.0, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[\"https://www.youtube.com/embed/GSycMV-_Csw?si=NsNv6ChB8496b-W_\"]", "[\"https://www.youtube.com/embed/tC-rRhQcnlI?si=SoatFGlxAsmBN7fD\"]", "2", "Reacher" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$uQCI6R039jhsy3EXnNtzk./ayy41uP.1N9Ntvpvkbg6ib9maS4g1S");
        }
    }
}
