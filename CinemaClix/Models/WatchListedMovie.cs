using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaClix.Models
{
    public class WatchListedMovie
    {
        [Key]
        public int id { get; set; }

        public string AddedBy { get; set; }

        public bool IsWatchListed { get; set; } = false;
        public int Movieid { get; set; }

    [ForeignKey(nameof(Movieid))]

        
        public Movie Movie { get; set; }
    }
}
