using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface ISubscriptionService
    {

        Task<Subscriptions> GetSubscriptions();

       SubscriptionPlans GetSubByPlanType(string PlanType);

        Task AddSubscription(Subscriptions subscriptions);

        
        Task<Subscriptions> GetSubscriptionsToCheckIfUserIsValidToAddSubscriptionAsync();

    }
}
