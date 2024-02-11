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

    
        public IEnumerable<SubscriptionPlans> GetSubscriptions()
        {
           return _appDBContext.SubscriptionPlans.ToList();
        }

      
    }
}
