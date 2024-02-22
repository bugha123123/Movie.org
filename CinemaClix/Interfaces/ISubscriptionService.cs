using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface ISubscriptionService
    {

        IEnumerable<SubscriptionPlans> GetSubscriptions();

       SubscriptionPlans GetSubByPlanType(string PlanType);

        Task AddSubscription(Subscriptions subscriptions);
    }
}
