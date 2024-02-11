using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
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

        public async Task AddSubscriptionToUser(int userId, Subscriptions subscription)
        {
            try
            {
                var user = await _appDBContext.Users.Include(u => u.Subscriptions).FirstOrDefaultAsync(u => u.Id == userId);

                if (user != null)
                {
                    user.Subscriptions ??= new List<Subscriptions>();
                    user.Subscriptions.Add(subscription);

                    await _appDBContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException($"User with Id {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the inner exception details
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                // Throw the exception again to preserve the original behavior
                throw;
            }
        }

    }
}
