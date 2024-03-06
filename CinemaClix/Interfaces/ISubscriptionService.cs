using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface ISubscriptionService
    {

        Task<Subscriptions> GetSubscriptions();

       SubscriptionPlans GetSubByPlanType(string PlanType);

        Task AddSubscription(Subscriptions subscriptions,string PlanType);

        
        Task<Subscriptions> GetSubscriptionsToCheckIfUserIsValidToAddSubscriptionAsync();

        Task<List<SubscriptionPlans>> GetSubscriptionPlansList();
        Task DeleteSubscriptionForUser(Subscriptions subscriptions);
        Task<string> CreateCheckoutSession(string planType, string successUrl);



    }
}
