using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty!")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        [MinLength(6, ErrorMessage = "Minimum length is 6 characters.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty!")]
        [MaxLength(40, ErrorMessage = "Maximum length is 40 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? GmailAddress { get; set; }

        [Required(ErrorMessage = "You can't leave this field empty!")]
        [MaxLength(60, ErrorMessage = "Maximum length is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters.")]
        public string? Password { get; set; }

   
       

        
    }
}
