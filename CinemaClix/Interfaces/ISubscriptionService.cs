namespace CinemaClix.Interfaces
{
    public interface ISubscriptionService
    {

        IEnumerable<SubscriptionPlans> GetSubscriptions();

       SubscriptionPlans GetSubById(int id);


    }
}
