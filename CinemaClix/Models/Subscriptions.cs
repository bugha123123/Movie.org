using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaClix.Models
{
    public class Subscriptions
    {
        [Key]
        public int SubscriptionId { get; set; }


        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

     
        public int SubscriptionPlansId { get; set; }

        [ForeignKey("SubscriptionPlansId")]
        public SubscriptionPlans SubscriptionPlans { get; set; }
    }
}
