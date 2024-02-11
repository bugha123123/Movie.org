using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmbedCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    SubscriptionPlansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.SubscriptionPlansId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GmailAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionPlansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlansId",
                        column: x => x.SubscriptionPlansId,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "SubscriptionPlansId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "EmbedCode", "Genre", "Image", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "A bachelor party gone wrong.", "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm", "Comedy", "https://m.media-amazon.com/images/M/MV5BNGQwZjg5YmYtY2VkNC00NzliLTljYTctNzI5NmU3MjE2ODQzXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", new DateTime(2009, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hangover" },
                    { 2, "Based on the true case files of paranormal investigators.", "https://www.youtube.com/embed/k10ETZ41q5o?si=nWLREnlD1OIxo-Ds", "Horror", "https://musicart.xboxlive.com/7/8ac41100-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080", new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Conjuring" },
                    { 3, "A tale of love, wealth, and tragedy in the Roaring Twenties.", "https://www.youtube.com/embed/nIewKn6EnAs?si=OLrl6d4S8kE2lj_7", "Romance", "https://m.media-amazon.com/images/M/MV5BMTkxNTk1ODcxNl5BMl5BanBnXkFtZTcwMDI1OTMzOQ@@._V1_FMjpg_UX1000_.jpg", new DateTime(2013, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { 4, "A high-octane post-apocalyptic action film.", "https://www.youtube.com/embed/hEJnMQG9ev8?si=FuiIkFOQQ1ONZ9u_", "Action", "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mad Max: Fury Road" },
                    { 5, "An animated underwater adventure to find a lost son.", "https://www.youtube.com/embed/wZdpNglLbt8?si=S5voA75MAG_mjVbq", "Comedy", "https://lumiere-a.akamaihd.net/v1/images/p_findingnemo_19752_05271d3f.jpeg?region=0%2C0%2C540%2C810", new DateTime(2003, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finding Nemo" },
                    { 6, "A heartwarming love story across decades.", "https://www.youtube.com/embed/BjJcYdEOI0k?si=BMadHTedURGAwZUI", "Drama", "https://m.media-amazon.com/images/M/MV5BNzc3Mzg1OGYtZjc3My00Y2NhLTgyOWUtYjRhMmI4OTkwNDg4XkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_.jpg", new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Notebook" },
                    { 7, "A dystopian future where artificial beings question their existence.", "https://www.youtube.com/embed/gCcx85zbxz4?si=3lnpek05_TeduKqP", "Adventure", "https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_.jpg", new DateTime(1982, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blade Runner" },
                    { 8, "A fairy tale adventure with love, humor, and sword fights.", "https://www.youtube.com/embed/O3CIXEAjcc8?si=DdlJdpK5Xg8Wgrx3", "Horror", "https://m.media-amazon.com/images/M/MV5BMTQwMTIzMTYyOV5BMl5BanBnXkFtZTYwOTI3MTk2._V1_.jpg", new DateTime(1987, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Princess Bride" },
                    { 9, "An astronaut's struggle for survival on Mars.", "https://www.youtube.com/embed/Ue4PCI0NamI?si=quRuKTUJdxnjDrB0", "Adventure", "https://lumiere-a.akamaihd.net/v1/images/image_a119dd78.jpeg?region=0%2C0%2C800%2C1200", new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Martian" },
                    { 10, "A psychological thriller set on an eerie island.", "https://www.youtube.com/embed/v8yrZSkKxTA?si=t4JzRlAXamclN8ux", "Horror", "https://m.media-amazon.com/images/M/MV5BYzhiNDkyNzktNTZmYS00ZTBkLTk2MDAtM2U0YjU1MzgxZjgzXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", new DateTime(2010, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shutter Island" },
                    { 11, "A mind-bending heist in dreams within dreams.", "https://www.youtube.com/embed/YoHD9XEInc0?si=q9osXK79R6eD4Ue3", "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwMzg5MDYyMw@@._V1_FMjpg_UX1000_.jpg", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 12, "A gritty and intense superhero film.", "https://www.youtube.com/embed/EXeTwQWrcwY?si=Zo_r5S1UQl2-w46s", "Action", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 13, "Dinosaurs come alive in a theme park.", "https://www.youtube.com/embed/lc0UehYemQA?si=_pNuZM-XRGmD7gBi", "Adventure", "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_FMjpg_UX1000_.jpg", new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { 14, "A story of hope and friendship in prison.", "https://www.youtube.com/embed/6hB3S9bIaco?si=3NTTLFhDS1iBi-n9", "Drama", "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg", new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { 15, "A man with a low IQ experiences key historical events.", "https://www.youtube.com/embed/bLvqoHBptjg?si=j8yWcQDqRTy2qUuE", "Drama", "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00YzQyLWE4NGMtNjM0ZDQyMmMwMzFkXkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_FMjpg_UX1000_.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { 16, "A computer hacker learns shocking truths about reality.", "https://www.youtube.com/embed/m8e-FF8MsqU?si=8sou_wIiTMqUCsIo", "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_FMjpg_UX1000_.jpg", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { 17, "A mafia epic depicting the Corleone family.", "https://www.youtube.com/embed/sY1S34973zA?si=t7Q3J-XlRUu3wY7k", "Crime", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 18, "An underground fight club that spirals out of control.", "https://www.youtube.com/embed/BdJKm16Co6M?si=4k-jeEdjR1eG2a4T", "Drama", "https://m.media-amazon.com/images/M/MV5BMjJmYTNkMTMtZWNkMy00OTkzLTg5YzktZGI0ZjU0MmQxMDdhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { 19, "A nonlinear narrative intertwining various criminal stories.", "https://www.youtube.com/embed/s7EdQ4FqbhY?si=jN_1gLJmSmuNt2oh", "Crime", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2QtODNmMjVhZjhlZjFiXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { 20, "A man with a low IQ experiences key historical events.", "https://www.youtube.com/embed/bLvqoHBptjg?si=j8yWcQDqRTy2qUuE", "Drama", "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00YzQyLWE4NGMtNjM0ZDQyMmMwMzFkXkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_FMjpg_UX1000_.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { 21, "A computer hacker learns shocking truths about reality.", "https://www.youtube.com/embed/m8e-FF8MsqU?si=8sou_wIiTMqUCsIo", "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_FMjpg_UX1000_.jpg", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "SubscriptionPlansId", "PlanPrice", "PlanType" },
                values: new object[,]
                {
                    { 1, "$9.99", "Basic" },
                    { 2, "$14.99", "Standard" },
                    { 3, "$19.99", "Premium" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionPlansId",
                table: "Subscriptions",
                column: "SubscriptionPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
