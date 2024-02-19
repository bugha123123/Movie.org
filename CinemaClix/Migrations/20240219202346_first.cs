using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cast = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmbedCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
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
                name: "Supports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.Id);
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
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "SubscriptionPlansId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Cast", "Description", "Director", "DirectorPhoto", "EmbedCode", "Genre", "Image", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "[\"https://images.mubicdn.net/images/cast_member/23435/cache-2118-1604949837/image-w856.jpg?size=x200\",\"https://www.filmibeat.com/img/125x160/popcorn/profile_photos/zach-galifianakis-7365.jpg\",\"https://m.media-amazon.com/images/M/MV5BMTk2MDQwODEwNV5BMl5BanBnXkFtZTcwNjc4MTY0NA@@._V1_QL75_UX140_CR0,0,140,140_.jpg\",\"https://images.mubicdn.net/images/cast_member/142648/cache-138129-1463176946/image-w856.jpg?size=x200\",\"https://images.mubicdn.net/images/cast_member/17568/cache-2872-1529943032/image-w856.jpg?size=x200\"]", "A bachelor party gone wrong.", "Todd Phillips", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c4/Todd_Phillips_%2829486703114%29.jpg/220px-Todd_Phillips_%2829486703114%29.jpg", "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm", "Comedy", "https://m.media-amazon.com/images/M/MV5BNGQwZjg5YmYtY2VkNC00NzliLTljYTctNzI5NmU3MjE2ODQzXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", 4, new DateTime(2009, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hangover" },
                    { 2, "[\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQuvmLbWaZ-xW8yh-x0U7LwzvfqgwfZt22zFaIezT7g0dbzFYBh\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTNAEmQ4iK04-aD9qQDmi40q0mf1KHIBrE3RtFcV6mEsGiD-u1y\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTJHjJ4osLEe4jR2eHITThivqrtqDNmB1FsuJR-GUIAXbQ9zPLx\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSDcwaGtfKmtIrkeIQRheUgEtwVLUQF6dIcxIvzH3TYrCpTHIdX\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQKo_O-ODw98iHQpsoKwFKdrG2wevekPUEHP0LOs9LRTzy2NuDZ\"]", "Based on the true case files of paranormal investigators.", "James Wan", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/James_Wan_in_2019.jpg/220px-James_Wan_in_2019.jpg", "https://www.youtube.com/embed/k10ETZ41q5o?si=nWLREnlD1OIxo-Ds", "Horror", "https://musicart.xboxlive.com/7/8ac41100-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080", 3, new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Conjuring" },
                    { 3, "[\"https://m.media-amazon.com/images/M/MV5BZGIzOTdmYTUtN2MwYy00OTYwLWI2NjItMGM5NWI4OWNkMTg4XkEyXkFqcGdeQXVyMTExNDQ2MTI@._V1_UY218_CR5,0,150,218_AL_.jpg\",\"http://t1.gstatic.com/images?q=tbn:ANd9GcTyKrKh94n5QjVouHveNZH0roOu1_pI-jC9mxSivBsnchM_F6Ei\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTXOWFjoXRVQun-tC6BlnUfp1KunpehDrBZTmva3nGku3xrQHYX\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSC-iura0AinWWuFC4sp49hlYzUWI4ctdmHIHomErlgTMN5w8Mw\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQca59lIsX6cXLNmRMle2fcCkURB4AvtkSqh-4Do1NwxEW49fNW\"]", "A tale of love, wealth, and tragedy in the Roaring Twenties.", "Baz Luhrmann", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Baz_Luhrmann%2C_%2852123943853%29.jpg/220px-Baz_Luhrmann%2C_%2852123943853%29.jpg", "https://www.youtube.com/embed/nIewKn6EnAs?si=OLrl6d4S8kE2lj_7", "Romance", "https://m.media-amazon.com/images/M/MV5BMTkxNTk1ODcxNl5BMl5BanBnXkFtZTcwMDI1OTMzOQ@@._V1_FMjpg_UX1000_.jpg", 5, new DateTime(2013, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { 4, "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Tom_Hardy_by_Gage_Skidmore.jpg/220px-Tom_Hardy_by_Gage_Skidmore.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/Charlize-theron-IMG_6045.jpg/220px-Charlize-theron-IMG_6045.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Nicholas_Hoult_%28cropped%29.jpg/220px-Nicholas_Hoult_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Hugh_Keays-Byrne_2019_%2832175116127%29_cropped.jpg/220px-Hugh_Keays-Byrne_2019_%2832175116127%29_cropped.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/b/b0/Paris_Motor_Show_2014_-_Land_Rover_Discovery_Sport_23_%28cropped%29.jpg/220px-Paris_Motor_Show_2014_-_Land_Rover_Discovery_Sport_23_%28cropped%29.jpg\"]", "A high-octane post-apocalyptic action film.", "George Miller", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/George_Miller_%2835706244922%29.jpg/220px-George_Miller_%2835706244922%29.jpg", "https://www.youtube.com/embed/hEJnMQG9ev8?si=FuiIkFOQQ1ONZ9u_", "Action", "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", 4, new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mad Max: Fury Road" },
                    { 5, "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Andrew_Stanton_cropped_2009.jpg/170px-Andrew_Stanton_cropped_2009.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/WilliamHMacyTIFFSept2012.jpg/220px-WilliamHMacyTIFFSept2012.jpg\"]", "An animated underwater adventure to find a lost son.", "Andrew Stanton", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Andrew_Stanton_cropped_2009.jpg/220px-Andrew_Stanton_cropped_2009.jpg", "https://www.youtube.com/embed/wZdpNglLbt8?si=S5voA75MAG_mjVbq", "Comedy", "https://lumiere-a.akamaihd.net/v1/images/p_findingnemo_19752_05271d3f.jpeg?region=0%2C0%2C540%2C810", 2, new DateTime(2003, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finding Nemo" },
                    { 6, "[\"https://www.usmagazine.com/wp-content/uploads/2022/11/The-Notebook-Cast-Where-Are-They-Now-092.jpg?w=800\\u0026h=450\\u0026%23038\",\"https://www.usmagazine.com/wp-content/uploads/2022/11/The-Notebook-Cast-Where-Are-They-Now-093.jpg?w=800\\u0026h=450\\u0026%23038\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTFi8UWJJY_7vRK0B29nu4A6KPSh6hsbgEdw2A9qoeqEvGuRHzA\"]", "A heartwarming love story across decades.", "Nick Cassavetes", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/NickCassavetesJune09.jpg/220px-NickCassavetesJune09.jpg", "https://www.youtube.com/embed/BjJcYdEOI0k?si=BMadHTedURGAwZUI", "Drama", "https://m.media-amazon.com/images/M/MV5BNzc3Mzg1OGYtZjc3My00Y2NhLTgyOWUtYjRhMmI4OTkwNDg4XkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_.jpg", 5, new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Notebook" },
                    { 7, "[\"https://www.tvguide.com/a/img/resize/2c1921bd0ebb271d24931221c0ce84d8a687fdcb/catalog/provider/10/9/10-57BF562A-9A70-446C-BDF9-60EA03E2E134.png?auto=webp\\u0026fit=crop\\u0026height=300\\u0026width=200\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSxye5wGz9yi6Tvf9eGAVaKQ5i3nig1jkT6nr6Xnmsbv1m4wWzo\",\"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSihAHL5QZPjNaY30jHKtQZ6vcR4Sa9ADoCHDkuegFGzZdEHE3J\"]", "A dystopian future where artificial beings question their existence.", "Ridley Scott", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg/220px-NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg", "https://www.youtube.com/embed/gCcx85zbxz4?si=3lnpek05_TeduKqP", "Adventure", "https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_.jpg", 4, new DateTime(1982, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blade Runner" },
                    { 8, "[\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTf0LAQomIIFCVZFKqw_TL-RU9JV9gVDjQqXIwhxX3nN323p7eV\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQgh99SZ6l0oke8eowhJLpD-w5akig37_VZHmc8ABRbHtKfpzNH\",\"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSPPSNwqmUCy3XYiToF8hjcx0a7kWJgqM0O7NqOdomF_I1w7czk\"]", "The film stars Ryan Kwanten as Jamie Ashen, a young widower returning to his hometown to search for answers to his wife's death", "Rob Reiner", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/James_Wan_in_2019.jpg/359px-James_Wan_in_2019.jpg", "https://www.youtube.com/embed/8b_HVtHmK30?si=VCsCCq9N9GDeQPxK", "Horror", "https://m.media-amazon.com/images/M/MV5BMTQwMTIzMTYyOV5BMl5BanBnXkFtZTYwOTI3MTk2._V1_.jpg", 2, new DateTime(1987, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dead Silence" },
                    { 9, "[\"https://images.mubicdn.net/images/cast_member/3493/cache-2153-1604741724/image-w856.jpg?size=x200\",\"https://www.tvguide.com/a/img/resize/7fe387a9c54f619918d93d9062870d65ef58e321/catalog/provider/10/9/10-40D59F1A-AC58-47FC-AF2B-03F6158ABC05.png?auto=webp\\u0026fit=crop\\u0026height=300\\u0026width=200\",\"https://televisionstats.com/_next/image?url=https%3A%2F%2Fimage.tmdb.org%2Ft%2Fp%2Fw154%2Fafs4PCiwn8LR93a10drULLVeVLo.jpg\\u0026w=384\\u0026q=75\"]", "An astronaut's struggle for survival on Mars.", "Ridley Scott", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg/220px-NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg", "https://www.youtube.com/embed/Ue4PCI0NamI?si=quRuKTUJdxnjDrB0", "Adventure", "https://lumiere-a.akamaihd.net/v1/images/image_a119dd78.jpeg?region=0%2C0%2C800%2C1200", 2, new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Martian" },
                    { 10, "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Leonardo_Dicaprio_Cannes_2019.jpg/220px-Leonardo_Dicaprio_Cannes_2019.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/1/11/Mark_Ruffalo_%2836201774756%29_%28cropped%29.jpg/220px-Mark_Ruffalo_%2836201774756%29_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Ben_Kingsley_by_Gage_Skidmore.jpg/220px-Ben_Kingsley_by_Gage_Skidmore.jpg\"]", "A psychological thriller set on an eerie island.", "Martin Scorsese", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Martin_Scorsese_MFF_2023.jpg/220px-Martin_Scorsese_MFF_2023.jpg", "https://www.youtube.com/embed/v8yrZSkKxTA?si=t4JzRlAXamclN8ux", "Horror", "https://m.media-amazon.com/images/M/MV5BYzhiNDkyNzktNTZmYS00ZTBkLTk2MDAtM2U0YjU1MzgxZjgzXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", 5, new DateTime(2010, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shutter Island" },
                    { 11, "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Leonardo_Dicaprio_Cannes_2019.jpg/220px-Leonardo_Dicaprio_Cannes_2019.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Ken_Watanabe_2007_%28cropped%29.jpg/220px-Ken_Watanabe_2007_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg/220px-Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg\"]", "A mind-bending heist in dreams within dreams.", "Christopher Nolan", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Christopher_Nolan_Cannes_2018.jpg/220px-Christopher_Nolan_Cannes_2018.jpg", "https://www.youtube.com/embed/YoHD9XEInc0?si=q9osXK79R6eD4Ue3", "Action", "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg", 5, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 12, "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Christian_Bale-7837.jpg/220px-Christian_Bale-7837.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/Michael_Caine_-_Viennale_2012_a_%28cropped%29.jpg/220px-Michael_Caine_-_Viennale_2012_a_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Heath_Ledger_%282%29.jpg/220px-Heath_Ledger_%282%29.jpg\"]", "A gritty and intense superhero film.", "Christopher Nolan", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Christopher_Nolan_Cannes_2018.jpg/220px-Christopher_Nolan_Cannes_2018.jpg", "https://www.youtube.com/embed/EXeTwQWrcwY?si=Zo_r5S1UQl2-w46s", "Action", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg", 5, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 13, "[\"https://ew.com/thmb/76cUn_VoM7Yg2AYRTBHcVYUV7C4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/BD-Wong-Jurassic-Park-060823-e0c520031edc45f2b0034b6e2b6efa77.jpg\",\"https://ew.com/thmb/FKzAwWQX_bKGe0MRxnDlb-hvMRE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Bob-Peck-Jurassic-Park-060823-72b6ddac4cd2471fab7f3d885cb53a0a.jpg\",\"https://m.media-amazon.com/images/M/MV5BYjk4MTBkYzEtZmZhYi00ZGFkLWJmYmYtOGRiY2IwYTNhMWFlXkEyXkFqcGdeQXVyMjQ0MTg4Nw@@._V1_UY256_CR16,0,172,256_AL_.jpg\"]", "Dinosaurs come alive in a theme park.", "Steven Spielberg", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/MKr25425_Steven_Spielberg_%28Berlinale_2023%29.jpg/220px-MKr25425_Steven_Spielberg_%28Berlinale_2023%29.jpg", "https://www.youtube.com/embed/lc0UehYemQA?si=_pNuZM-XRGmD7gBi", "Adventure", "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_FMjpg_UX1000_.jpg", 3, new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { 14, "[\"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRdNAmgAHv3IEcUH06lxWJhWDbqaVMV--dBylaJbgMnuBbojtEX\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcThZehyH9DPF1WJLxA2-DT_0SKny_sSJubllj0tl8A5uc2bN_Pd\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQ3Nk_FmLzJ5RhBkaanb4sJdQdbYzcAQj88Idvib7e0i5y87w8W\"]", "A story of hope and friendship in prison.", "Frank Darabont", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Frank_Darabont_at_the_PaleyFest_2011_-_The_Walking_Dead_panel.jpg/220px-Frank_Darabont_at_the_PaleyFest_2011_-_The_Walking_Dead_panel.jpg", "https://www.youtube.com/embed/6hB3S9bIaco?si=3NTTLFhDS1iBi-n9", "Drama", "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg", 5, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { 15, "[\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbIFJCE30YRbo9jTfUNgZW3imhRpIW6CJwJ0da6xnKiRgelgLq\",\"https://m.media-amazon.com/images/M/MV5BNDE1NGY4ODAtODMxMS00YjU2LTk3ZWItMDFkNDAzOWJhZDE0XkEyXkFqcGdeQXVyNTgzMzk4NDQ@._V1_.jpg\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSj5cZr--Yueur5d8Ld8xNh3xTsifPisbfldVGtdlPVztT0OA6S\"]", "A man with a low IQ experiences key historical events.", "Robert Zemeckis", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Robert_Zemeckis_%22The_Walk%22_at_Opening_Ceremony_of_the_28th_Tokyo_International_Film_Festival_%2821835891403%29_%28cropped%29.jpg/220px-Robert_Zemeckis_%22The_Walk%22_at_Opening_Ceremony_of_the_28th_Tokyo_International_Film_Festival_%2821835891403%29_%28cropped%29.jpg", "https://www.youtube.com/embed/bLvqoHBptjg?si=j8yWcQDqRTy2qUuE", "Drama", "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p15829_v_v13_aa.jpg", 3, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { 16, "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%2846806576944%29_%28cropped%29.jpg/220px-Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%2846806576944%29_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/National_Memorial_Day_Concert_2017_%2834117818524%29_%28cropped%29.jpg/220px-National_Memorial_Day_Concert_2017_%2834117818524%29_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Carrie-Anne_Moss_May_2016.jpg/220px-Carrie-Anne_Moss_May_2016.jpg\"]", "A computer hacker learns shocking truths about reality.", "The Wachowskis", "https://m.media-amazon.com/images/M/MV5BMTU1Mjc1MjkzNV5BMl5BanBnXkFtZTgwOTc1NDQ1ODE@._V1_.jpg", "https://www.youtube.com/embed/m8e-FF8MsqU?si=8sou_wIiTMqUCsIo", "Action", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg", 3, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { 17, "[\"https://people.com/thmb/ea5JdZLLGgLQbTqZCUH3B15bCtk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/marlon-brando-the-godfather-ca5cfb9768c54e6090dfbc144547b5b9.jpg\",\"https://people.com/thmb/CPTln9aPH7r8ULrglsjBPPjshh4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/robert-duvall-the-godfather-de08805e3d5947d69036b65768107e32.jpg\",\"https://people.com/thmb/P2SKkDNL7Z0z6KtUITUA3riQO_0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/al-pacino-the-godfather-33d1309ed2c745ac9c3ca7562f96df8b.jpg\"]", "A mafia epic depicting the Corleone family.", "Francis Ford Coppola", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Francis_Ford_Coppola_%2833906700778%29_%28cropped%29.jpg/220px-Francis_Ford_Coppola_%2833906700778%29_%28cropped%29.jpg", "https://www.youtube.com/embed/sY1S34973zA?si=t7Q3J-XlRUu3wY7k", "Crime", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", 2, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 18, "[\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQJBntbqy_AhBhpkcGci8VP79LSwcheGgaj4BEeWLy9pUK3KOy7\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQvYLIEzqWSEciLkKfUNyccomlEM7LC-xsVHO8VNGg8KuauyVFE\",\"https://m.media-amazon.com/images/M/MV5BMjI1NDQwMDA5N15BMl5BanBnXkFtZTgwMDI2OTQ1NDM@._V1_UY256_CR106,0,172,256_AL_.jpg\"]", "An underground fight club that spirals out of control.", "David Fincher", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/TheKillerBFILFF051023_%288_of_22%29_%2853255176376%29_%28cropped2%29.jpg/800px-TheKillerBFILFF051023_%288_of_22%29_%2853255176376%29_%28cropped2%29.jpg", "https://www.youtube.com/embed/BdJKm16Co6M?si=4k-jeEdjR1eG2a4T", "Drama", "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", 3, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { 19, "[\"https://people.com/thmb/U1tEKq-06zEfiYjNrZdWbUnaM1U=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(599x0:601x2)/pulp-fiction-bruce-willis-22e31b70c39c472f93909220aa87f9ab.jpg\",\"https://pagesix.com/wp-content/uploads/sites/3/2019/10/amanda-plummer-pulp-fiction.jpg?quality=80\\u0026strip=all\\u0026w=878\",\"https://people.com/thmb/3EBJt_w7BTArTCRvZcTWwJ_7la8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(599x0:601x2)/pulp-fiction-tim-roth-418bfec481234c3c9b4583101fcb6781.jpg\"]", "A nonlinear narrative intertwining various criminal stories.", "Pulp Fiction", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Quentin_Tarantino_by_Gage_Skidmore.jpg/800px-Quentin_Tarantino_by_Gage_Skidmore.jpg", "https://www.youtube.com/embed/s7EdQ4FqbhY?si=jN_1gLJmSmuNt2oh", "Crime", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2QtODNmMjVhZjhlZjFiXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", 1, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Description", "EmbedCode", "Genre", "Length", "Photo", "PosterImage", "Seasons", "ShowName" },
                values: new object[,]
                {
                    { 1, "Stranger Things is an American science fiction horror drama television series created by the Duffer Brothers for Netflix", "https://www.youtube.com/embed/mnd7sFt5c3A?si=olf4i4xqnbMRmnTp", "Horror", "8h 20min", "https://m.media-amazon.com/images/M/MV5BMDZkYmVhNjMtNWU4MC00MDQxLWE3MjYtZGMzZWI1ZjhlOWJmXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg", "https://thecrimsonwhite.com/wp-content/uploads/2022/06/stranger-900x506.png", "4", "Stranger Things" },
                    { 2, "Reacher is an American action crime streaming television series developed by Nick Santora for Amazon Prime Video", "https://www.youtube.com/embed/GSycMV-_Csw?si=NsNv6ChB8496b-W_", "Action", "4h 50min", "https://lh3.googleusercontent.com/proxy/yi4kg53vZfPYG3zPmTrEljqiXaQ3fcJ7Zga8co09Uw74rQb_x3IhDeRK5cMAqN3jAmsd4xBF8tTVTNi7MMJOoyTtj4IyabdHjMHvPQ", "https://blog.richersounds.com/wp-content/uploads/2022/03/1_mEMiafsmsUsSs4eD-rd8_Q.jpeg", "2", "Reacher" }
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
                name: "IX_Subscriptions_SubscriptionPlanId",
                table: "Subscriptions",
                column: "SubscriptionPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");
        }
    }
}
