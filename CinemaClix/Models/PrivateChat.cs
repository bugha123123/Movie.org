using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class PrivateChat 
    {
        [Key]
        public int PrivatChatId { get; set; }
        public int RecipientId { get; set; }

        public bool IsRead { get; set; }

        public string RecipientUserName { get; set; }
        public string SenderUserName { get; set; }

        [Required(ErrorMessage = "You can't leave this field out")]
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    }
}
