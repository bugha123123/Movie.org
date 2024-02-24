using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class UserWatchList
    {
        [Key]
        public int Id { get; set; }


        public string AddedBy { get; set; }

        public string MovieTitle { get; set; }



        public Movie Movies { get; set; }

        public bool isWatchListed { get; set; }



    }
}
