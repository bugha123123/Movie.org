using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }

        public string ShowName { get; set; }
        public string Length { get; set; }

        public string Seasons { get; set; }

        public string Genre { get; set; }

        public string Photo { get; set; }
    }
}
