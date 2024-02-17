using CinemaClix.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SubscriptionPlans
{
    [Key]
    public int SubscriptionPlansId { get; set; }

    public string PlanType { get; set; }

    public string PlanPrice { get; set; }

    public ICollection<Subscriptions> Subscriptions { get; set; }
}
