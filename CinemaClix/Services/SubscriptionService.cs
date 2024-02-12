using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly AppDBContext _appDBContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubscriptionService(AppDBContext appDBContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDBContext = appDBContext;
            _httpContextAccessor = httpContextAccessor;
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
