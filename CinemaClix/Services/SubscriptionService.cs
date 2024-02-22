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

        public async Task AddSubscription(Subscriptions subscriptions)
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(CookieUserId, out int LoggedInUser))
            {
                var FoundUser = await _userService.GetUserById(LoggedInUser);
           

                if (FoundUser != null)
                {
                    Subscriptions NewSubscription = new Subscriptions()
                    {
                        AddedBy = FoundUser.GmailAddress!,
                        PlanType = "9.99$",
                        SubscriptionPlanId = FoundUser.Id
                    };

                    await _appDBContext.Subscriptions.AddAsync(NewSubscription);
                    await _appDBContext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("User not found for the given ID or SubscriptionPlans not found for the given PlanType");
                }
            }
            else
            {
                Console.WriteLine("Invalid UserId in the cookie");
            }
        }



        public SubscriptionPlans GetSubByPlanType(string PlanType)
        {
            SubscriptionPlans subscription = _appDBContext.SubscriptionPlans.FirstOrDefault(s => s.PlanType == PlanType)!;


            return subscription;
        }

        public IEnumerable<SubscriptionPlans> GetSubscriptions()
        {
           return _appDBContext.SubscriptionPlans.ToList();
        }

     

    }
}
