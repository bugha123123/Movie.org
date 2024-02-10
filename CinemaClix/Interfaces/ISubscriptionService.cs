namespace CinemaClix.Interfaces
{
    public interface ISubscriptionService
    {

        IEnumerable<SubscriptionPlans> GetSubscriptions();

        
    }
}
