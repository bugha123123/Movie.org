using System.ComponentModel.DataAnnotations;

public class SubscriptionPlans
{
    [Key]
    public int SubscriptionPlansId { get; set; }

    public string PlanType { get; set; }

    public string PlanPrice { get; set; }
}
