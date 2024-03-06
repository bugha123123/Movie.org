using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaClix.Models
{
    public class Subscriptions
    {
        [Key]
        public int SubscriptionId { get; set; }


        public string AddedBy { get; set; }

        public string PlanType { get; set; }

        public int SubscriptionPlanId { get; set; }
        [ForeignKey("SubscriptionPlanId")]
        public  SubscriptionPlans SubscriptionPlan { get; set; }
    }
}
