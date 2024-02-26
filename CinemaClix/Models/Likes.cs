using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaClix.Models
{
    public class Likes
    {
        [Key]
        public int LikeId { get; set; }

        public int  MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }

        public int UserId { get; set; }

        public string MovieImage { get; set; }


        public string MovieTitle { get; set; }

        
    }
}
