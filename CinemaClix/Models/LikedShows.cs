using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class LikedShows
    {
        [Key]
        public int LikeId { get; set; }

        public int ShowId { get; set; }
        [ForeignKey(nameof(ShowId))]
        public Show Show { get; set; }



        public int UserId { get; set; }

        public string ShowImage { get; set; }


        public string ShowTitle { get; set; }
    }
}
