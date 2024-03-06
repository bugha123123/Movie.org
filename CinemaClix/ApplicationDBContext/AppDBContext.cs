using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.ApplicationDBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<SubscriptionPlans> SubscriptionPlans { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Support> Supports { get; set; }
public DbSet<WatchListedMovie> watchListedMovies { get; set; }
        public DbSet<WatchListedShow> watchListedShows { get; set; }
        public DbSet<PrivateChat> privateChats { get; set; }
        public DbSet<Likes> Likes { get; set; }

        public DbSet<LikedShows> LikedShows { get; set; }
        public DbSet<Chat> Chat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<SubscriptionPlans>().HasData(
                new SubscriptionPlans { SubscriptionPlansId = 1, PlanType = "Basic", PlanPrice = "$9.99" },
                new SubscriptionPlans { SubscriptionPlansId = 2, PlanType = "Standard", PlanPrice = "$14.99" },
                new SubscriptionPlans { SubscriptionPlansId = 3, PlanType = "Premium", PlanPrice = "$19.99" }
            );

            modelBuilder.Entity<User>().HasData(
     new User
     {
         Id = 1,
         GmailAddress = "admin@gmail.com",
         Password = BCrypt.Net.BCrypt.HashPassword("admin"),
         UserName = "admin",
         Role = "Admin",
         Suspended = false
      
     }
 );




            modelBuilder.Entity<Show>().HasData(

                new Show
                {
                    Id = 1,
                    ShowName = "Stranger Things",
                    Length = "8h 20min",
                    Genre = "Horror",
                    Photo = "https://m.media-amazon.com/images/M/MV5BMDZkYmVhNjMtNWU4MC00MDQxLWE3MjYtZGMzZWI1ZjhlOWJmXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg",
                    Seasons = "4",
                    PosterImage = "https://sm.ign.com/t/ign_me/review/s/stranger-t/stranger-things-season-1-review_fjsz.1200.jpg",
                    Season1 = new List<string>() {
                    "https://www.youtube.com/embed/mnd7sFt5c3A?si=olf4i4xqnbMRmnTp"
                    },
                    Season2 = new List<string>()
                    {
                        "https://www.youtube.com/embed/R1ZXOOLMJ8s?si=kQEV8_729iyoS7LH"
                    },
                    Director = "Duffer Brothers",
                    DirectorPhoto = "https://www.dga.org/-/media/Images/DGAQ-Article-Images/1703-Summer-2017/DGAQSummer2017GenNextDufferBrothers.ashx?la=en&hash=4F8968AAA3974674E109777DC46D45C2E890C353",
                    Cast = new List<string>()
                    {
                        "https://people.com/thmb/hwBdMyWZOAXw9UnBe2qQfnyHepo=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/caleb-2000-bbffc3890d6d4ae2a3f348829f35216a.jpg",
                        "https://people.com/thmb/EVHoFjXXjVnTZOjm1YYbIxYM2CI=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/millie2-2000-d8a6aaace09a42838c65dde7b4a28802.jpg",
                        "https://people.com/thmb/YqYhcAUzArq0Wi4lyCnGepSofL8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/charlie-2000-e5e0595535fc48f08ef70757d8405432.jpg",
                        "https://people.com/thmb/vKmZ4PRmW5hxggoqPVB1vnTaJCk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/natalia-2000-40091f6a9dbf491b88b669ac38c39888.jpg",
                        "https://people.com/thmb/fyKBmN-cOaEQsvYmCZ-26AG9ngw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/gaten-2000-48499c525a7c42259b95322b423fa7bb.jpg"
                    },
                    Description = "Stranger Things is an American science fiction horror drama television series created by the Duffer Brothers for Netflix",
                    Rating = 4.6,
                    ReleaseDate = new DateTime(2020, 6, 5),
                   


                },


                new Show
                {
                    Id = 2,
                    ShowName = "Reacher",
                    Length = "4h 50min",
                    Genre = "Action",
                    Photo = "https://m.media-amazon.com/images/I/81XLYQOXR+L._AC_UF894,1000_QL80_.jpg",
                    Seasons = "2",
                    PosterImage = "https://blog.richersounds.com/wp-content/uploads/2022/03/1_mEMiafsmsUsSs4eD-rd8_Q.jpeg",
                    Season1 = new List<string>()
                   {
                       "https://www.youtube.com/embed/GSycMV-_Csw?si=NsNv6ChB8496b-W_"
                   },
                    Season2 = new List<string>()
                    {
                        "https://www.youtube.com/embed/tC-rRhQcnlI?si=SoatFGlxAsmBN7fD"
                    },
                    Description = "Reacher is an American action crime streaming television series developed by Nick Santora for Amazon Prime Video",
                    Director = "Christopher McQuarrie",
                    DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/de/Christopher_McQuarrie_2022.jpg/220px-Christopher_McQuarrie_2022.jpg",
                    Rating = 3,
                    ReleaseDate = new DateTime(2020, 6, 5),
                    Cast = new List<string>()
                    {
                        "https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Alan-Ritchson-plays-Jack-Reacher-a055dcb.jpg?quality=90&fit=700,466",
                        "https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Hugh-Thompson-plays-Baker-e72f064.jpg?quality=90&fit=700,466",
                        "http://t1.gstatic.com/images?q=tbn:ANd9GcQF4q-z9k7fFnNcKkytdApskFiKgpg-yFFn1Jfy5F6cmpeIETYU",
                        "https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Malcolm-Goodwin-plays-Oscar-Finley-3d21000.jpg?quality=90&fit=700,466",
                        "https://images.immediate.co.uk/production/volatile/sites/3/2022/02/Willa-Fitzgerald-plays-Roscoe-Conklin-43a4a95.jpg?quality=90&fit=700,466"
                    }
                   
                    

                }
                ) ;


            modelBuilder.Entity<Movie>().HasData(
      new Movie
      {
          Id = 1,
          Title = "The Hangover",
          Genre = "Comedy",
          Description = "A bachelor party gone wrong.",
          ReleaseDate = new DateTime(2009, 6, 5),
          Image = "https://m.media-amazon.com/images/M/MV5BNGQwZjg5YmYtY2VkNC00NzliLTljYTctNzI5NmU3MjE2ODQzXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm",
          Rating = 4,
          Director = "Todd Phillips",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c4/Todd_Phillips_%2829486703114%29.jpg/220px-Todd_Phillips_%2829486703114%29.jpg",
          Cast = new List<string>()
          {
              "https://images.mubicdn.net/images/cast_member/23435/cache-2118-1604949837/image-w856.jpg?size=x200",
              "https://www.filmibeat.com/img/125x160/popcorn/profile_photos/zach-galifianakis-7365.jpg",
              "https://m.media-amazon.com/images/M/MV5BMTk2MDQwODEwNV5BMl5BanBnXkFtZTcwNjc4MTY0NA@@._V1_QL75_UX140_CR0,0,140,140_.jpg",
              "https://images.mubicdn.net/images/cast_member/142648/cache-138129-1463176946/image-w856.jpg?size=x200",
              "https://images.mubicdn.net/images/cast_member/17568/cache-2872-1529943032/image-w856.jpg?size=x200"
          }
      },
      new Movie
      {
          Id = 2,
          Title = "The Conjuring",
          Genre = "Horror",
          Description = "Based on the true case files of paranormal investigators.",
          ReleaseDate = new DateTime(2013, 7, 19),
          Image = "https://musicart.xboxlive.com/7/8ac41100-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080",
          EmbedCode = "https://www.youtube.com/embed/k10ETZ41q5o?si=nWLREnlD1OIxo-Ds",
          Rating = 3,
          Director = "James Wan",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/James_Wan_in_2019.jpg/220px-James_Wan_in_2019.jpg",
          Cast = new List<string>()
          {
              "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQuvmLbWaZ-xW8yh-x0U7LwzvfqgwfZt22zFaIezT7g0dbzFYBh",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTNAEmQ4iK04-aD9qQDmi40q0mf1KHIBrE3RtFcV6mEsGiD-u1y",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTJHjJ4osLEe4jR2eHITThivqrtqDNmB1FsuJR-GUIAXbQ9zPLx",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSDcwaGtfKmtIrkeIQRheUgEtwVLUQF6dIcxIvzH3TYrCpTHIdX",
              "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQKo_O-ODw98iHQpsoKwFKdrG2wevekPUEHP0LOs9LRTzy2NuDZ"
          }
      },
      new Movie
      {
          Id = 3,
          Title = "The Great Gatsby",
          Genre = "Romance",
          Description = "A tale of love, wealth, and tragedy in the Roaring Twenties.",
          ReleaseDate = new DateTime(2013, 5, 10),
          Image = "https://m.media-amazon.com/images/M/MV5BMTkxNTk1ODcxNl5BMl5BanBnXkFtZTcwMDI1OTMzOQ@@._V1_FMjpg_UX1000_.jpg",
          EmbedCode = "https://www.youtube.com/embed/nIewKn6EnAs?si=OLrl6d4S8kE2lj_7",
          Rating = 5,
          Director = "Baz Luhrmann",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Baz_Luhrmann%2C_%2852123943853%29.jpg/220px-Baz_Luhrmann%2C_%2852123943853%29.jpg",
          Cast = new List<string>()
          {
              "https://m.media-amazon.com/images/M/MV5BZGIzOTdmYTUtN2MwYy00OTYwLWI2NjItMGM5NWI4OWNkMTg4XkEyXkFqcGdeQXVyMTExNDQ2MTI@._V1_UY218_CR5,0,150,218_AL_.jpg",
              "http://t1.gstatic.com/images?q=tbn:ANd9GcTyKrKh94n5QjVouHveNZH0roOu1_pI-jC9mxSivBsnchM_F6Ei",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTXOWFjoXRVQun-tC6BlnUfp1KunpehDrBZTmva3nGku3xrQHYX",
              "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSC-iura0AinWWuFC4sp49hlYzUWI4ctdmHIHomErlgTMN5w8Mw",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQca59lIsX6cXLNmRMle2fcCkURB4AvtkSqh-4Do1NwxEW49fNW"
          }
      },
      new Movie
      {
          Id = 4,
          Title = "Mad Max: Fury Road",
          Genre = "Action",
          Description = "A high-octane post-apocalyptic action film.",
          ReleaseDate = new DateTime(2015, 5, 15),
          Image = "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/hEJnMQG9ev8?si=FuiIkFOQQ1ONZ9u_",
          Rating = 4,
          Director = "George Miller",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/George_Miller_%2835706244922%29.jpg/220px-George_Miller_%2835706244922%29.jpg",
          Cast = new List<string>()
          {
              "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Tom_Hardy_by_Gage_Skidmore.jpg/220px-Tom_Hardy_by_Gage_Skidmore.jpg",
              "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/Charlize-theron-IMG_6045.jpg/220px-Charlize-theron-IMG_6045.jpg",
              "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Nicholas_Hoult_%28cropped%29.jpg/220px-Nicholas_Hoult_%28cropped%29.jpg",
              "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Hugh_Keays-Byrne_2019_%2832175116127%29_cropped.jpg/220px-Hugh_Keays-Byrne_2019_%2832175116127%29_cropped.jpg",
              "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b0/Paris_Motor_Show_2014_-_Land_Rover_Discovery_Sport_23_%28cropped%29.jpg/220px-Paris_Motor_Show_2014_-_Land_Rover_Discovery_Sport_23_%28cropped%29.jpg"
          }
      },
      new Movie
      {
          Id = 5,
          Title = "Finding Nemo",
          Genre = "Comedy",
          Description = "An animated underwater adventure to find a lost son.",
          ReleaseDate = new DateTime(2003, 5, 30),
          Image = "https://lumiere-a.akamaihd.net/v1/images/p_findingnemo_19752_05271d3f.jpeg?region=0%2C0%2C540%2C810",
          EmbedCode = "https://www.youtube.com/embed/wZdpNglLbt8?si=S5voA75MAG_mjVbq",
          Rating = 2,
          Director = "Andrew Stanton",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Andrew_Stanton_cropped_2009.jpg/220px-Andrew_Stanton_cropped_2009.jpg",
          Cast = new List<string>()
          {
              "https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Andrew_Stanton_cropped_2009.jpg/170px-Andrew_Stanton_cropped_2009.jpg",
              "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/WilliamHMacyTIFFSept2012.jpg/220px-WilliamHMacyTIFFSept2012.jpg"
          }
      },
      new Movie
      {
          Id = 6,
          Title = "The Notebook",
          Genre = "Drama",
          Description = "A heartwarming love story across decades.",
          ReleaseDate = new DateTime(2004, 6, 25),
          Image = "https://m.media-amazon.com/images/M/MV5BNzc3Mzg1OGYtZjc3My00Y2NhLTgyOWUtYjRhMmI4OTkwNDg4XkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/BjJcYdEOI0k?si=BMadHTedURGAwZUI",
          Rating = 5,
          Director = "Nick Cassavetes",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/NickCassavetesJune09.jpg/220px-NickCassavetesJune09.jpg",
          Cast = new List<string>()
          {
              "https://www.usmagazine.com/wp-content/uploads/2022/11/The-Notebook-Cast-Where-Are-They-Now-092.jpg?w=800&h=450&%23038",
              "https://www.usmagazine.com/wp-content/uploads/2022/11/The-Notebook-Cast-Where-Are-They-Now-093.jpg?w=800&h=450&%23038",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTFi8UWJJY_7vRK0B29nu4A6KPSh6hsbgEdw2A9qoeqEvGuRHzA"
          }

      },
      new Movie
      {
          Id = 7,
          Title = "Blade Runner",
          Genre = "Adventure",
          Description = "A dystopian future where artificial beings question their existence.",
          ReleaseDate = new DateTime(1982, 6, 25),
          Image = "https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/gCcx85zbxz4?si=3lnpek05_TeduKqP",
          Rating = 4,
          Director = "Ridley Scott",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg/220px-NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg",
          Cast = new List<string>()
          {
              "https://www.tvguide.com/a/img/resize/2c1921bd0ebb271d24931221c0ce84d8a687fdcb/catalog/provider/10/9/10-57BF562A-9A70-446C-BDF9-60EA03E2E134.png?auto=webp&fit=crop&height=300&width=200",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSxye5wGz9yi6Tvf9eGAVaKQ5i3nig1jkT6nr6Xnmsbv1m4wWzo",
              "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSihAHL5QZPjNaY30jHKtQZ6vcR4Sa9ADoCHDkuegFGzZdEHE3J"
          }
      },
      new Movie
      {
          Id = 8,
          Title = "The Dead Silence",
          Genre = "Horror",
          Description = "The film stars Ryan Kwanten as Jamie Ashen, a young widower returning to his hometown to search for answers to his wife's death",
          ReleaseDate = new DateTime(1987, 9, 25),
          Image = "https://m.media-amazon.com/images/M/MV5BMTQwMTIzMTYyOV5BMl5BanBnXkFtZTYwOTI3MTk2._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/8b_HVtHmK30?si=VCsCCq9N9GDeQPxK",
          Rating = 2,
          Director = "Rob Reiner",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/James_Wan_in_2019.jpg/359px-James_Wan_in_2019.jpg",
          Cast = new List<string>()
          {
             "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTf0LAQomIIFCVZFKqw_TL-RU9JV9gVDjQqXIwhxX3nN323p7eV",
             "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQgh99SZ6l0oke8eowhJLpD-w5akig37_VZHmc8ABRbHtKfpzNH",
             "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSPPSNwqmUCy3XYiToF8hjcx0a7kWJgqM0O7NqOdomF_I1w7czk"
          }
      },
      new Movie
      {
          Id = 9,
          Title = "The Martian",
          Genre = "Adventure",
          Description = "An astronaut's struggle for survival on Mars.",
          ReleaseDate = new DateTime(2015, 10, 2),
          Image = "https://lumiere-a.akamaihd.net/v1/images/image_a119dd78.jpeg?region=0%2C0%2C800%2C1200",
          EmbedCode = "https://www.youtube.com/embed/Ue4PCI0NamI?si=quRuKTUJdxnjDrB0",
          Rating = 2,
          Director = "Ridley Scott",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg/220px-NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg",
          Cast = new List<string>()
          {
             "https://images.mubicdn.net/images/cast_member/3493/cache-2153-1604741724/image-w856.jpg?size=x200",
             "https://www.tvguide.com/a/img/resize/7fe387a9c54f619918d93d9062870d65ef58e321/catalog/provider/10/9/10-40D59F1A-AC58-47FC-AF2B-03F6158ABC05.png?auto=webp&fit=crop&height=300&width=200",
             "https://televisionstats.com/_next/image?url=https%3A%2F%2Fimage.tmdb.org%2Ft%2Fp%2Fw154%2Fafs4PCiwn8LR93a10drULLVeVLo.jpg&w=384&q=75"
          }
      },
      new Movie
      {
          Id = 10,
          Title = "Shutter Island",
          Genre = "Horror",
          Description = "A psychological thriller set on an eerie island.",
          ReleaseDate = new DateTime(2010, 2, 19),
          Image = "https://m.media-amazon.com/images/M/MV5BYzhiNDkyNzktNTZmYS00ZTBkLTk2MDAtM2U0YjU1MzgxZjgzXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/v8yrZSkKxTA?si=t4JzRlAXamclN8ux",
          Rating = 5,
          Director = "Martin Scorsese",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Martin_Scorsese_MFF_2023.jpg/220px-Martin_Scorsese_MFF_2023.jpg",
          Cast = new List<string>()
          {
             "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Leonardo_Dicaprio_Cannes_2019.jpg/220px-Leonardo_Dicaprio_Cannes_2019.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/1/11/Mark_Ruffalo_%2836201774756%29_%28cropped%29.jpg/220px-Mark_Ruffalo_%2836201774756%29_%28cropped%29.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Ben_Kingsley_by_Gage_Skidmore.jpg/220px-Ben_Kingsley_by_Gage_Skidmore.jpg"
          }
      },
 // Additional Movies
 new Movie
 {
     Id = 11,
     Title = "Inception",
     Genre = "Action",
     Description = "A mind-bending heist in dreams within dreams.",
     ReleaseDate = new DateTime(2010, 7, 16),
     Image = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg",
     EmbedCode = "https://www.youtube.com/embed/YoHD9XEInc0?si=q9osXK79R6eD4Ue3",
     Rating = 5,
     Director = "Christopher Nolan",
     DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Christopher_Nolan_Cannes_2018.jpg/220px-Christopher_Nolan_Cannes_2018.jpg",
     Cast = new List<string>()
          {
             "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Leonardo_Dicaprio_Cannes_2019.jpg/220px-Leonardo_Dicaprio_Cannes_2019.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Ken_Watanabe_2007_%28cropped%29.jpg/220px-Ken_Watanabe_2007_%28cropped%29.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg/220px-Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg"
          }
 },
    new Movie
    {
        Id = 12,
        Title = "The Dark Knight",
        Genre = "Action",
        Description = "A gritty and intense superhero film.",
        ReleaseDate = new DateTime(2008, 7, 18),
        Image = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg",
        EmbedCode = "https://www.youtube.com/embed/EXeTwQWrcwY?si=Zo_r5S1UQl2-w46s",
        Rating = 5,
        Director = "Christopher Nolan",
        DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Christopher_Nolan_Cannes_2018.jpg/220px-Christopher_Nolan_Cannes_2018.jpg",
        Cast = new List<string>()
          {
             "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Christian_Bale-7837.jpg/220px-Christian_Bale-7837.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/Michael_Caine_-_Viennale_2012_a_%28cropped%29.jpg/220px-Michael_Caine_-_Viennale_2012_a_%28cropped%29.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Heath_Ledger_%282%29.jpg/220px-Heath_Ledger_%282%29.jpg"
          }
    },
    new Movie
    {
        Id = 13,
        Title = "Jurassic Park",
        Genre = "Adventure",
        Description = "Dinosaurs come alive in a theme park.",
        ReleaseDate = new DateTime(1993, 6, 11),
        Image = "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_FMjpg_UX1000_.jpg",
        EmbedCode = "https://www.youtube.com/embed/lc0UehYemQA?si=_pNuZM-XRGmD7gBi",
        Rating = 3,
        Director = "Steven Spielberg",
        DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/MKr25425_Steven_Spielberg_%28Berlinale_2023%29.jpg/220px-MKr25425_Steven_Spielberg_%28Berlinale_2023%29.jpg",
        Cast = new List<string>()
          {
             "https://ew.com/thmb/76cUn_VoM7Yg2AYRTBHcVYUV7C4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/BD-Wong-Jurassic-Park-060823-e0c520031edc45f2b0034b6e2b6efa77.jpg",
             "https://ew.com/thmb/FKzAwWQX_bKGe0MRxnDlb-hvMRE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Bob-Peck-Jurassic-Park-060823-72b6ddac4cd2471fab7f3d885cb53a0a.jpg",
             "https://m.media-amazon.com/images/M/MV5BYjk4MTBkYzEtZmZhYi00ZGFkLWJmYmYtOGRiY2IwYTNhMWFlXkEyXkFqcGdeQXVyMjQ0MTg4Nw@@._V1_UY256_CR16,0,172,256_AL_.jpg"
          }
    },
    new Movie
    {
        Id = 14,
        Title = "The Shawshank Redemption",
        Genre = "Drama",
        Description = "A story of hope and friendship in prison.",
        ReleaseDate = new DateTime(1994, 9, 23),
        Image = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg",
        EmbedCode = "https://www.youtube.com/embed/6hB3S9bIaco?si=3NTTLFhDS1iBi-n9",
        Rating = 5,
        Director = "Frank Darabont",
        DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Frank_Darabont_at_the_PaleyFest_2011_-_The_Walking_Dead_panel.jpg/220px-Frank_Darabont_at_the_PaleyFest_2011_-_The_Walking_Dead_panel.jpg",

        Cast = new List<string>()
          {
             "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRdNAmgAHv3IEcUH06lxWJhWDbqaVMV--dBylaJbgMnuBbojtEX",
             "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcThZehyH9DPF1WJLxA2-DT_0SKny_sSJubllj0tl8A5uc2bN_Pd",
             "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQ3Nk_FmLzJ5RhBkaanb4sJdQdbYzcAQj88Idvib7e0i5y87w8W"
          }
    },
    new Movie
    {
        Id = 15,
        Title = "Forrest Gump",
        Genre = "Drama",
        Description = "A man with a low IQ experiences key historical events.",
        ReleaseDate = new DateTime(1994, 7, 6),
        Image = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p15829_v_v13_aa.jpg",
        EmbedCode = "https://www.youtube.com/embed/bLvqoHBptjg?si=j8yWcQDqRTy2qUuE",
        Rating = 3,
        Director = "Robert Zemeckis",
        DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Robert_Zemeckis_%22The_Walk%22_at_Opening_Ceremony_of_the_28th_Tokyo_International_Film_Festival_%2821835891403%29_%28cropped%29.jpg/220px-Robert_Zemeckis_%22The_Walk%22_at_Opening_Ceremony_of_the_28th_Tokyo_International_Film_Festival_%2821835891403%29_%28cropped%29.jpg",

        Cast = new List<string>()
          {
             "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbIFJCE30YRbo9jTfUNgZW3imhRpIW6CJwJ0da6xnKiRgelgLq",
             "https://m.media-amazon.com/images/M/MV5BNDE1NGY4ODAtODMxMS00YjU2LTk3ZWItMDFkNDAzOWJhZDE0XkEyXkFqcGdeQXVyNTgzMzk4NDQ@._V1_.jpg",
             "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSj5cZr--Yueur5d8Ld8xNh3xTsifPisbfldVGtdlPVztT0OA6S"
          }
    },
    new Movie
    {
        Id = 16,
        Title = "The Matrix",
        Genre = "Action",
        Description = "A computer hacker learns shocking truths about reality.",
        ReleaseDate = new DateTime(1999, 3, 31),
        Image = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg",
        EmbedCode = "https://www.youtube.com/embed/m8e-FF8MsqU?si=8sou_wIiTMqUCsIo",
        Rating = 3,
        Director = "The Wachowskis",
        DirectorPhoto = "https://m.media-amazon.com/images/M/MV5BMTU1Mjc1MjkzNV5BMl5BanBnXkFtZTgwOTc1NDQ1ODE@._V1_.jpg",
        Cast = new List<string>()
          {
             "https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%2846806576944%29_%28cropped%29.jpg/220px-Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%2846806576944%29_%28cropped%29.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/National_Memorial_Day_Concert_2017_%2834117818524%29_%28cropped%29.jpg/220px-National_Memorial_Day_Concert_2017_%2834117818524%29_%28cropped%29.jpg",
             "https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Carrie-Anne_Moss_May_2016.jpg/220px-Carrie-Anne_Moss_May_2016.jpg"
          }
    },
      // Add more movies as needed...
      new Movie
      {
          Id = 17,
          Title = "The Godfather",
          Genre = "Crime",
          Description = "A mafia epic depicting the Corleone family.",
          ReleaseDate = new DateTime(1972, 3, 24),
          Image = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
          EmbedCode = "https://www.youtube.com/embed/sY1S34973zA?si=t7Q3J-XlRUu3wY7k",
          Rating = 2,
          Director = "Francis Ford Coppola",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Francis_Ford_Coppola_%2833906700778%29_%28cropped%29.jpg/220px-Francis_Ford_Coppola_%2833906700778%29_%28cropped%29.jpg",
          Cast = new List<string>()
          {
             "https://people.com/thmb/ea5JdZLLGgLQbTqZCUH3B15bCtk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/marlon-brando-the-godfather-ca5cfb9768c54e6090dfbc144547b5b9.jpg",
             "https://people.com/thmb/CPTln9aPH7r8ULrglsjBPPjshh4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/robert-duvall-the-godfather-de08805e3d5947d69036b65768107e32.jpg",
             "https://people.com/thmb/P2SKkDNL7Z0z6KtUITUA3riQO_0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/al-pacino-the-godfather-33d1309ed2c745ac9c3ca7562f96df8b.jpg"
          }
      },
      new Movie
      {
          Id = 18,
          Title = "Fight Club",
          Genre = "Drama",
          Description = "An underground fight club that spirals out of control.",
          ReleaseDate = new DateTime(1999, 10, 15),
          Image = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/BdJKm16Co6M?si=4k-jeEdjR1eG2a4T",
          Rating = 3,
          Director = "David Fincher",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/TheKillerBFILFF051023_%288_of_22%29_%2853255176376%29_%28cropped2%29.jpg/800px-TheKillerBFILFF051023_%288_of_22%29_%2853255176376%29_%28cropped2%29.jpg",
          Cast = new List<string>()
          {
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQJBntbqy_AhBhpkcGci8VP79LSwcheGgaj4BEeWLy9pUK3KOy7",
              "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQvYLIEzqWSEciLkKfUNyccomlEM7LC-xsVHO8VNGg8KuauyVFE",
              "https://m.media-amazon.com/images/M/MV5BMjI1NDQwMDA5N15BMl5BanBnXkFtZTgwMDI2OTQ1NDM@._V1_UY256_CR106,0,172,256_AL_.jpg"
          }
      },
      new Movie
      {
          Id = 19,
          Title = "Pulp Fiction",
          Genre = "Crime",
          Description = "A nonlinear narrative intertwining various criminal stories.",
          ReleaseDate = new DateTime(1994, 10, 14),
          Image = "https://static.posters.cz/image/750/posters/pulp-fiction-cover-i1288.jpg",
          EmbedCode = "https://www.youtube.com/embed/s7EdQ4FqbhY?si=jN_1gLJmSmuNt2oh",
          Rating = 1,
          Director = "Pulp Fiction",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Quentin_Tarantino_by_Gage_Skidmore.jpg/800px-Quentin_Tarantino_by_Gage_Skidmore.jpg",
          Cast = new List<string>()
          {
              "https://people.com/thmb/U1tEKq-06zEfiYjNrZdWbUnaM1U=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(599x0:601x2)/pulp-fiction-bruce-willis-22e31b70c39c472f93909220aa87f9ab.jpg",
              "https://pagesix.com/wp-content/uploads/sites/3/2019/10/amanda-plummer-pulp-fiction.jpg?quality=80&strip=all&w=878",
              "https://people.com/thmb/3EBJt_w7BTArTCRvZcTWwJ_7la8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(599x0:601x2)/pulp-fiction-tim-roth-418bfec481234c3c9b4583101fcb6781.jpg"
          }
      }) ;
   


        }
    }


    }

