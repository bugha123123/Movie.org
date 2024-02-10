using CinemaClix.Models;
using System.ComponentModel.DataAnnotations;

public class Subscriptions
{
    [Key]
    public int SubscriptionId { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public int SubscriptionPlansId { get; set; }
    public SubscriptionPlans? SubscriptionPlans { get; set; }
}
