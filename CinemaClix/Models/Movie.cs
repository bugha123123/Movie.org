namespace CinemaClix.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string EmbedCode { get; set; }

        public string Image { get; set; }

        public int Rating { get; set; }

        public string Director { get; set; }

        public string DirectorPhoto { get; set; }

        public List<string> Cast { get; set; }


    }
}
