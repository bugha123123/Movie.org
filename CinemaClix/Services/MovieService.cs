using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class MovieService : IMovieService
    {

        private readonly AppDBContext _dbContext;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MovieService(AppDBContext dbContext, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task AddToWatchlist(Movie Movie)
        {
            var LoggedInUser = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
         
            int.TryParse(LoggedInUser, out int  User);

            var FoundUser = await _userService.GetUserById(User);
            var FoundMovie = _dbContext.Movies.FirstOrDefaultAsync(m => m.Id ==  Movie.Id);
            if (FoundUser != null && FoundMovie != null)
            {
               
                   
            };
              

               
           
          

        }



        public Movie GetMovieById(int id)
        {
            Movie movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie not found"); 
            }

            return movie;
        }




        public List<Movie> GetMovieList()
        {
         return _dbContext.Movies.ToList();
        }

    
        public List<Movie> GetMoviesByCategory(string category)
        {
            return _dbContext.Movies.Where(m => m.Genre == category).ToList();
        }

        public IEnumerable<Movie> GetPopularMoviesByGenre(string genre, int rating)
        {
            var genreMovies = GetMoviesByCategory(genre); 
            var popularMovies = genreMovies.Where(m => m.Rating > rating);

            return popularMovies;
        }

        public Task WatchListMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
