using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly AppDBContext _appDBContext;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubscriptionService(AppDBContext appDBContext, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _appDBContext = appDBContext;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
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
