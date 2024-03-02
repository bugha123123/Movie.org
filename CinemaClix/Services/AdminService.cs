﻿using CinemaClix.ApplicationDBContext;
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

        public async Task AddMovie(Movie movie)
        {
            _appDBContext.Movies.Add(movie);
           await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Likes>> GetLikedMovies()
        {
          return await _appDBContext.Likes.ToListAsync();
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

        public async Task<List<User>> GetSuspendedUser()
        {
            return await _appDBContext.Users.Where(u => u.Suspended == true).ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _appDBContext.Users
                .Where(user => user.Role != "Admin" && user.Suspended != true)
                .ToListAsync();
        }

        public async Task GiveAccessToUsers(int userId)
        {
            var suspendedUser = await _appDBContext.Users.FirstOrDefaultAsync(u => u.Id == userId && u.Suspended); ;

            if (suspendedUser != null)
            {
                suspendedUser.Suspended = false;
                await _appDBContext.SaveChangesAsync();
            }
        }

        public async Task SuspendUser(int userId)
        {
            var userToSuspend = await _appDBContext.Users
                .Where(user => user.Id == userId)
                .FirstOrDefaultAsync();

            if (userToSuspend != null)
            {
                userToSuspend.Suspended = true;

                await _appDBContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("User not found", nameof(userId));
            }
        }
    }
}
