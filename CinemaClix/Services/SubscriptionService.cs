using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;

namespace CinemaClix.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly AppDBContext _appDBContext;

        public SubscriptionService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public SubscriptionPlans GetSubById(int id)
        {
         SubscriptionPlans Subscription = _appDBContext.SubscriptionPlans.FirstOrDefault(x => x.SubscriptionPlansId == id)!;

            return Subscription;
        }

        public IEnumerable<SubscriptionPlans> GetSubscriptions()
        {
           return _appDBContext.SubscriptionPlans.ToList();
        }

      
    }
}
