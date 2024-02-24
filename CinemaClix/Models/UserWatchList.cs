using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class UserWatchList
    {
        [Key]
        public int Id { get; set; }


        public string AddedBy { get; set; }

        public int  UserId { get; set; }

        public int WatchListedMovieId { get; set; }

        public Movie WatchListedMovie { get; set; }

        public bool isWatchListed { get; set; }



    }
}
