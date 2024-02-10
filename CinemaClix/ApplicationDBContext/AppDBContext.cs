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
          EmbedCode = "https://www.youtube.com/embed/tlize92ffnY?si=8_7TYqfFhuA7IrRm"
         },
         new Movie
         {
             Id = 2,
             Title = "The Conjuring",
             Genre = "Horror",
             Description = "Based on the true case files of paranormal investigators.",
             ReleaseDate = new DateTime(2013, 7, 19),
             Image = "https://musicart.xboxlive.com/7/8ac41100-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080",
             EmbedCode = "https://www.youtube.com/embed/k10ETZ41q5o?si=nWLREnlD1OIxo-Ds"
         },
         new Movie
         {
             Id = 3,
             Title = "The Great Gatsby",
             Genre = "Romance",
             Description = "A tale of love, wealth, and tragedy in the Roaring Twenties.",
             ReleaseDate = new DateTime(2013, 5, 10),
             Image = "https://m.media-amazon.com/images/M/MV5BMTkxNTk1ODcxNl5BMl5BanBnXkFtZTcwMDI1OTMzOQ@@._V1_FMjpg_UX1000_.jpg",
             EmbedCode = "https://www.youtube.com/embed/nIewKn6EnAs?si=OLrl6d4S8kE2lj_7"
         },
         new Movie
         {
             Id = 4,
             Title = "Mad Max: Fury Road",
             Genre = "Action",
             Description = "A high-octane post-apocalyptic action film.",
             ReleaseDate = new DateTime(2015, 5, 15),
             Image = "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
             EmbedCode = "https://www.youtube.com/embed/hEJnMQG9ev8?si=FuiIkFOQQ1ONZ9u_"
         },
         new Movie
         {
             Id = 5,
             Title = "Finding Nemo",
             Genre = "Comedy",
             Description = "An animated underwater adventure to find a lost son.",
             ReleaseDate = new DateTime(2003, 5, 30),
             Image = "https://lumiere-a.akamaihd.net/v1/images/p_findingnemo_19752_05271d3f.jpeg?region=0%2C0%2C540%2C810",
             EmbedCode = "https://www.youtube.com/embed/wZdpNglLbt8?si=S5voA75MAG_mjVbq"
         },
         new Movie
         {
             Id = 6,
             Title = "The Notebook",
             Genre = "Drama",
             Description = "A heartwarming love story across decades.",
             ReleaseDate = new DateTime(2004, 6, 25),
             Image = "https://m.media-amazon.com/images/M/MV5BNzc3Mzg1OGYtZjc3My00Y2NhLTgyOWUtYjRhMmI4OTkwNDg4XkEyXkFqcGdeQXVyMTU3NDU4MDg2._V1_.jpg",
             EmbedCode = "https://www.youtube.com/embed/BjJcYdEOI0k?si=BMadHTedURGAwZUI"
         },
         new Movie
         {
             Id = 7,
             Title = "Blade Runner",
             Genre = "Adventure",
             Description = "A dystopian future where artificial beings question their existence.",
             ReleaseDate = new DateTime(1982, 6, 25),
             Image = "https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_.jpg",
             EmbedCode = "https://www.youtube.com/embed/gCcx85zbxz4?si=3lnpek05_TeduKqP"
         },
         new Movie
         {
             Id = 8,
             Title = "The Princess Bride",
             Genre = "Horror",
             Description = "A fairy tale adventure with love, humor, and sword fights.",
             ReleaseDate = new DateTime(1987, 9, 25),
             Image = "https://m.media-amazon.com/images/M/MV5BMTQwMTIzMTYyOV5BMl5BanBnXkFtZTYwOTI3MTk2._V1_.jpg",
             EmbedCode = "https://www.youtube.com/embed/O3CIXEAjcc8?si=DdlJdpK5Xg8Wgrx3"
         },
         new Movie
         {
             Id = 9,
             Title = "The Martian",
             Genre = "Adventure",
             Description = "An astronaut's struggle for survival on Mars.",
             ReleaseDate = new DateTime(2015, 10, 2),
             Image = "https://lumiere-a.akamaihd.net/v1/images/image_a119dd78.jpeg?region=0%2C0%2C800%2C1200",
             EmbedCode = "https://www.youtube.com/embed/Ue4PCI0NamI?si=quRuKTUJdxnjDrB0"
         },
         new Movie
         {
             Id = 10,
             Title = "Shutter Island",
             Genre = "Horror",
             Description = "A psychological thriller set on an eerie island.",
             ReleaseDate = new DateTime(2010, 2, 19),
             Image = "https://m.media-amazon.com/images/M/MV5BYzhiNDkyNzktNTZmYS00ZTBkLTk2MDAtM2U0YjU1MzgxZjgzXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
             EmbedCode = "https://www.youtube.com/embed/v8yrZSkKxTA?si=t4JzRlAXamclN8ux"
         }
     );


        }
    }


    }

