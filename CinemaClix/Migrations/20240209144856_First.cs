using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
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
                columns: new[] { "Id", "Description", "Genre", "Image", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "A bachelor party gone wrong.", "Comedy", "hangover.jpg", new DateTime(2009, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hangover" },
                    { 2, "Based on the true case files of paranormal investigators.", "Horror", "conjuring.jpg", new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Conjuring" },
                    { 3, "A tale of love, wealth, and tragedy in the Roaring Twenties.", "Romance", "great_gatsby.jpg", new DateTime(2013, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { 4, "A high-octane post-apocalyptic action film.", "Action", "mad_max.jpg", new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mad Max: Fury Road" },
                    { 5, "An animated underwater adventure to find a lost son.", "Animation", "finding_nemo.jpg", new DateTime(2003, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finding Nemo" },
                    { 6, "A heartwarming love story across decades.", "Drama", "notebook.jpg", new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Notebook" },
                    { 7, "A dystopian future where artificial beings question their existence.", "Science Fiction", "blade_runner.jpg", new DateTime(1982, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blade Runner" },
                    { 8, "A fairy tale adventure with love, humor, and sword fights.", "Fantasy", "princess_bride.jpg", new DateTime(1987, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Princess Bride" },
                    { 9, "An astronaut's struggle for survival on Mars.", "Adventure", "martian.jpg", new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Martian" },
                    { 10, "A psychological thriller set on an eerie island.", "Mystery", "shutter_island.jpg", new DateTime(2010, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shutter Island" }
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
