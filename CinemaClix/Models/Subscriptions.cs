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

        [ForeignKey("SubscriptionPlan")]
        public int SubscriptionPlanId { get; set; }

        public  SubscriptionPlans SubscriptionPlan { get; set; }
    }
}
