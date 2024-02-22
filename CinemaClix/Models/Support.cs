using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class Support
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="You can't leave this field empty")]
        [MaxLength(15)]
        [MinLength(5)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty")]
        [MaxLength(15)]
        [MinLength(5)]
        public string LastName { get; set; }

        
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty")]
        [MaxLength(15)]
        [MinLength(8)]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty")]
        [MaxLength(80)]
        public  string Comment { get; set; }
    }
}
