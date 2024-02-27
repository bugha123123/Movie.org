using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaClix.Models
{
    public class WatchListedShow

    {
        [Key]
        public int Id { get; set; }

        public string AddedBy { get; set; }

        public string AddedByUserName { get; set; }
        public bool IsWatchListed { get; set; } = false;
        public int ShowId { get; set; }

        public string Director { get; set; }
        public string Image { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string ShowTitle { get; set; }

        [ForeignKey(nameof(ShowId))]


        public Show Show { get; set; }
    }
}
