using System.ComponentModel.DataAnnotations;

namespace CinemaClix.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Sender { get; set; }

        public int  SenderId { get; set; }

        public string SenderRole { get; set; }

        [Required(ErrorMessage ="You can't leave this field out")]
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
