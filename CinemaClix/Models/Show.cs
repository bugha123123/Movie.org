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

        public List<string> Season1 { get; set; }

        public List<string> Season2 { get; set; }


        public string Genre { get; set; }

        public string Photo { get; set; }
        public string PosterImage { get; set; }

        public  string Director  { get; set; }

        public string DirectorPhoto { get; set; }

        public DateTime ReleaseDate  { get; set; }

        public List<string> Cast { get; set; }

        public double  Rating { get; set; }

        public string Description { get; set; }
    }
}
