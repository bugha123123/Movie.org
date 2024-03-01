using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDBContext _appDBContext;

        public AdminService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<List<LikedShows>> GetLikedShows()
        {
            return await _appDBContext.LikedShows.ToListAsync();
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _appDBContext.Movies.ToListAsync();
        }

        public async Task<List<Show>> GetShows()
        {
            return await _appDBContext.Shows.ToListAsync();
        }

        public async Task<List<Subscriptions>> GetSubscriptions()
        {
           return await _appDBContext.Subscriptions.ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
           return await _appDBContext.Users.ToListAsync();  
        }
    }
}
