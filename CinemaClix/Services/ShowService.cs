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

        public async Task<Show> GetShowById(int Id)
        {
           var FoundShowById = await _dbContext.Shows.FirstOrDefaultAsync(i => i.Id == Id);

            if (FoundShowById == null)
            {
                throw new Exception("User By that Id Not found GO TO (GETSHOWSBYID())");
            }

            return FoundShowById;
        }
    }
}
