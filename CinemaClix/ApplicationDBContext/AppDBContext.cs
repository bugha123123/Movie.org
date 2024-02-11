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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriptions>()
                .HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Subscriptions>()
                .HasOne(s => s.SubscriptionPlans)
                .WithMany()
                .HasForeignKey(s => s.SubscriptionPlansId);

            modelBuilder.Entity<SubscriptionPlans>().HasData(
                new SubscriptionPlans { SubscriptionPlansId = 1, PlanType = "Basic", PlanPrice = "$9.99" },
                new SubscriptionPlans { SubscriptionPlansId = 2, PlanType = "Standard", PlanPrice = "$14.99" },
                new SubscriptionPlans { SubscriptionPlansId = 3, PlanType = "Premium", PlanPrice = "$19.99" }
            );


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
          Rating = "⭐⭐⭐⭐",
          Director= "Todd Phillips",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c4/Todd_Phillips_%2829486703114%29.jpg/220px-Todd_Phillips_%2829486703114%29.jpg"
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
          Rating = "⭐⭐⭐",
          Director= "James Wan",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/James_Wan_in_2019.jpg/220px-James_Wan_in_2019.jpg"
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
          Rating = "⭐⭐⭐⭐⭐",
          Director= "Baz Luhrmann",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Baz_Luhrmann%2C_%2852123943853%29.jpg/220px-Baz_Luhrmann%2C_%2852123943853%29.jpg"
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
          Rating = "⭐⭐⭐⭐",
          Director= "George Miller",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/George_Miller_%2835706244922%29.jpg/220px-George_Miller_%2835706244922%29.jpg"
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
          Rating = "⭐⭐⭐",
          Director= "Andrew Stanton",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/en/thumb/2/29/Finding_Nemo.jpg/220px-Finding_Nemo.jpg"
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
          Rating = "⭐⭐⭐⭐⭐",
          Director= "Nick Cassavetes",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/NickCassavetesJune09.jpg/220px-NickCassavetesJune09.jpg"

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
          Rating = "⭐⭐⭐⭐",
          Director= "Ridley Scott",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg/220px-NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg"
      },
      new Movie
      {
          Id = 8,
          Title = "The Princess Bride",
          Genre = "Horror",
          Description = "A fairy tale adventure with love, humor, and sword fights.",
          ReleaseDate = new DateTime(1987, 9, 25),
          Image = "https://m.media-amazon.com/images/M/MV5BMTQwMTIzMTYyOV5BMl5BanBnXkFtZTYwOTI3MTk2._V1_.jpg",
          EmbedCode = "https://www.youtube.com/embed/O3CIXEAjcc8?si=DdlJdpK5Xg8Wgrx3",
          Rating = "⭐⭐⭐⭐",
          Director= "Rob Reiner",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/1/11/Rob_Reiner_MFF_2016.jpg/220px-Rob_Reiner_MFF_2016.jpg"
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
          Rating = "⭐⭐",
          Director= "Ridley Scott",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg/220px-NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%E2%80%9D_%28201508180030HQ%29.jpg"

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
          Rating = "⭐⭐⭐⭐⭐",
          Director= "Martin Scorsese",
          DirectorPhoto="https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Martin_Scorsese_MFF_2023.jpg/220px-Martin_Scorsese_MFF_2023.jpg"
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
     Rating = "⭐⭐⭐⭐⭐",
     Director= "Christopher Nolan",
     DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Christopher_Nolan_Cannes_2018.jpg/220px-Christopher_Nolan_Cannes_2018.jpg"
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
        Rating = "⭐⭐⭐⭐⭐",
        Director= "Christopher Nolan",
        DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Christopher_Nolan_Cannes_2018.jpg/220px-Christopher_Nolan_Cannes_2018.jpg"
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
        Rating = "⭐⭐⭐",
        Director="Steven Spielberg",
        DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/MKr25425_Steven_Spielberg_%28Berlinale_2023%29.jpg/220px-MKr25425_Steven_Spielberg_%28Berlinale_2023%29.jpg"
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
        Rating = "⭐⭐⭐⭐⭐",
        Director= "Frank Darabont",
        DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Frank_Darabont_at_the_PaleyFest_2011_-_The_Walking_Dead_panel.jpg/220px-Frank_Darabont_at_the_PaleyFest_2011_-_The_Walking_Dead_panel.jpg"
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
        Rating = "⭐⭐⭐",
        Director= "Robert Zemeckis",
        DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Robert_Zemeckis_%22The_Walk%22_at_Opening_Ceremony_of_the_28th_Tokyo_International_Film_Festival_%2821835891403%29_%28cropped%29.jpg/220px-Robert_Zemeckis_%22The_Walk%22_at_Opening_Ceremony_of_the_28th_Tokyo_International_Film_Festival_%2821835891403%29_%28cropped%29.jpg"
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
        Rating = "⭐⭐⭐",
        Director= "The Wachowskis",
        DirectorPhoto= "https://m.media-amazon.com/images/M/MV5BMTU1Mjc1MjkzNV5BMl5BanBnXkFtZTgwOTc1NDQ1ODE@._V1_.jpg"
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
          Rating = "⭐⭐",
          Director= "Francis Ford Coppola",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Francis_Ford_Coppola_%2833906700778%29_%28cropped%29.jpg/220px-Francis_Ford_Coppola_%2833906700778%29_%28cropped%29.jpg"
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
          Rating = "⭐⭐⭐",
          Director = "David Fincher",
          DirectorPhoto= "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/TheKillerBFILFF051023_%288_of_22%29_%2853255176376%29_%28cropped2%29.jpg/800px-TheKillerBFILFF051023_%288_of_22%29_%2853255176376%29_%28cropped2%29.jpg"
      },
      new Movie
      {
          Id = 19,
          Title = "Pulp Fiction",
          Genre = "Crime",
          Description = "A nonlinear narrative intertwining various criminal stories.",
          ReleaseDate = new DateTime(1994, 10, 14),
          Image = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2QtODNmMjVhZjhlZjFiXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
          EmbedCode = "https://www.youtube.com/embed/s7EdQ4FqbhY?si=jN_1gLJmSmuNt2oh",
          Rating = "⭐",
          Director = "Pulp Fiction",
          DirectorPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Quentin_Tarantino_by_Gage_Skidmore.jpg/800px-Quentin_Tarantino_by_Gage_Skidmore.jpg"
      });
   


        }
    }


    }

