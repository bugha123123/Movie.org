using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class ShowService : IShowService
    {

        private readonly AppDBContext _dbContext;

        public ShowService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Show>> GetShowByGenre(string Genre)
        {
     var Shows =    await   _dbContext.Shows.Where(i => i.Genre == Genre).ToListAsync();

            return Shows;
        }
    }
}
