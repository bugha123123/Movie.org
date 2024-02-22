using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class Support
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="You can't leave this field empty")]
        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty")]
       
        public string LastName { get; set; }


        public string EmailAddress { get; set; } = "wanda73@ethereal.email";

        [Required(ErrorMessage = "You can't leave this field empty")]
     
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty")]
        
        public  string Comment { get; set; }
    }
}
